using Boxly.Api.Models.DTOs;
using Boxly.Api.Models.Entities;
using Boxly.Api.Models.Enums;
using Boxly.Api.Models.Events;
using Boxly.Api.Patterns.Facade;
using Boxly.Api.Patterns.Strategy;
using Boxly.Api.Repositories;

namespace Boxly.Api.Services;

public interface ISuscripcionService
{
    Task<ResultadoOperacionDto<CotizacionResponseDto>> CotizarAsync(string cajaSlug, TipoPlan tipoPlan);
    Task<ResultadoOperacionDto<Suscripcion>> CrearSuscripcionAsync(CrearSuscripcionDto dto);
    Task<ResultadoOperacionDto<Suscripcion>> CancelarSuscripcionAsync(string id);
    Task<IEnumerable<Suscripcion>> ObtenerSuscripcionesAsync();
    Task<Suscripcion?> ObtenerPorIdAsync(string id);
}

public class SuscripcionService : ISuscripcionService
{
    private readonly ICajaRepository _cajaRepository;
    private readonly ISuscripcionRepository _suscripcionRepository;
    private readonly IFacturacionFacade _facturacionFacade;
    private readonly ISuscripcionNotifier _suscripcionNotifier;
    private readonly IAsignacionStrategy _asignacionStrategy;
    private readonly ILogger<SuscripcionService> _logger;

    public SuscripcionService(
        ICajaRepository cajaRepository,
        ISuscripcionRepository suscripcionRepository,
        IFacturacionFacade facturacionFacade,
        ISuscripcionNotifier suscripcionNotifier,
        IAsignacionStrategy asignacionStrategy,
        ILogger<SuscripcionService> logger)
    {
        _cajaRepository = cajaRepository;
        _suscripcionRepository = suscripcionRepository;
        _facturacionFacade = facturacionFacade;
        _suscripcionNotifier = suscripcionNotifier;
        _asignacionStrategy = asignacionStrategy;
        _logger = logger;
    }

    public async Task<ResultadoOperacionDto<CotizacionResponseDto>> CotizarAsync(string cajaSlug, TipoPlan tipoPlan)
    {
        var caja = await _cajaRepository.ObtenerPorSlugAsync(cajaSlug);
        if (caja == null)
        {
            return ResultadoOperacionDto<CotizacionResponseDto>.Fallo(
                $"La caja temática con identificador '{cajaSlug}' no existe en el catálogo."
            );
        }

        var prefactura = _facturacionFacade.LiquidarPreFactura(caja, tipoPlan);
        return ResultadoOperacionDto<CotizacionResponseDto>.Ok(prefactura, "Pre-factura calculada correctamente.");
    }

    public async Task<ResultadoOperacionDto<Suscripcion>> CrearSuscripcionAsync(CrearSuscripcionDto dto)
    {
        // 1. Validar existencia de la caja (Flujo alternativo: 404)
        var caja = await _cajaRepository.ObtenerPorSlugAsync(dto.CajaSlug);
        if (caja == null)
        {
            _logger.LogWarning("Intento de suscripción a caja inexistente: {Slug}", dto.CajaSlug);
            return ResultadoOperacionDto<Suscripcion>.Fallo(
                $"La caja temática solicitada ('{dto.CajaSlug}') no fue encontrada en el sistema."
            );
        }

        // 2. Validar stock (Flujo alternativo: sin stock disponible)
        if (caja.StockDisponible <= 0)
        {
            _logger.LogWarning("Intento de suscripción sin stock para la caja {Slug}", caja.Slug);
            return ResultadoOperacionDto<Suscripcion>.Fallo(
                $"No hay existencias disponibles en este momento para la caja '{caja.Nombre}'."
            );
        }

        // 3. Liquidar montos con Facade
        var prefactura = _facturacionFacade.LiquidarPreFactura(caja, dto.TipoPlan);

        // 4. Instanciar entidad Suscripción
        var suscripcion = new Suscripcion
        {
            CajaSlug = caja.Slug,
            CajaNombre = caja.Nombre,
            TipoPlan = dto.TipoPlan,
            UsuarioNombre = dto.NombreCliente.Trim(),
            UsuarioEmail = dto.Email.Trim().ToLowerInvariant(),
            DireccionEnvio = dto.Direccion.Trim(),
            Ciudad = dto.Ciudad.Trim(),
            Telefono = dto.Telefono.Trim(),
            MetodoPago = dto.MetodoPago,
            CostoPlan = prefactura.ValorPlan,
            CostoEnvio = prefactura.CostoEnvio,
            MontoTotal = prefactura.TotalPagar,
            Estado = EstadoSuscripcion.PendientePago,
            FechaCreacion = DateTime.UtcNow
        };

        // 5. Procesar pago con la pasarela a través de la Fachada (RN-04)
        var resultadoPago = _facturacionFacade.ProcesarPagoSimulado(suscripcion, dto);

        if (!resultadoPago.Aprobado)
        {
            // Flujo Alternativo: Pago fallido / rechazado
            var anterior = suscripcion.Estado;
            suscripcion.Estado = EstadoSuscripcion.PagoRechazado;
            suscripcion.MotivoRechazo = resultadoPago.Mensaje;

            await _suscripcionRepository.GuardarAsync(suscripcion);
            await _suscripcionNotifier.NotificarCambioEstadoAsync(
                suscripcion,
                anterior,
                $"Pago rechazado: {resultadoPago.Mensaje}"
            );

            return new ResultadoOperacionDto<Suscripcion>
            {
                Exitoso = false,
                Mensaje = resultadoPago.Mensaje,
                Datos = suscripcion,
                Errores = new List<string> { resultadoPago.Mensaje }
            };
        }

        // 6. Happy Path: Pago aprobado -> Activar suscripción (RN-04)
        var estadoAnterior = suscripcion.Estado;
        suscripcion.Estado = EstadoSuscripcion.Activa;
        suscripcion.FechaActivacion = DateTime.UtcNow;

        // Descuenta stock
        caja.StockDisponible--;

        await _suscripcionRepository.GuardarAsync(suscripcion);

        // Notificar observadores (Observer GoF)
        await _suscripcionNotifier.NotificarCambioEstadoAsync(
            suscripcion,
            estadoAnterior,
            $"Suscripción activada con transacción {resultadoPago.TransaccionId}"
        );

        return ResultadoOperacionDto<Suscripcion>.Ok(
            suscripcion,
            $"¡Suscripción confirmada y activa exitosamente! ID de referencia: {suscripcion.Id}"
        );
    }

    public async Task<ResultadoOperacionDto<Suscripcion>> CancelarSuscripcionAsync(string id)
    {
        var suscripcion = await _suscripcionRepository.ObtenerPorIdAsync(id);
        if (suscripcion == null)
        {
            return ResultadoOperacionDto<Suscripcion>.Fallo($"No se encontró ninguna suscripción con el ID '{id}'.");
        }

        if (suscripcion.Estado == EstadoSuscripcion.Cancelada)
        {
            return ResultadoOperacionDto<Suscripcion>.Fallo("La suscripción ya se encuentra en estado cancelado.");
        }

        var anterior = suscripcion.Estado;
        suscripcion.Estado = EstadoSuscripcion.Cancelada;

        await _suscripcionRepository.ActualizarAsync(suscripcion);
        await _suscripcionNotifier.NotificarCambioEstadoAsync(
            suscripcion,
            anterior,
            "Suscripción cancelada por solicitud del usuario."
        );

        return ResultadoOperacionDto<Suscripcion>.Ok(suscripcion, "La suscripción fue cancelada satisfactoriamente.");
    }

    public async Task<IEnumerable<Suscripcion>> ObtenerSuscripcionesAsync()
    {
        return await _suscripcionRepository.ObtenerTodasAsync();
    }

    public async Task<Suscripcion?> ObtenerPorIdAsync(string id)
    {
        return await _suscripcionRepository.ObtenerPorIdAsync(id);
    }
}
