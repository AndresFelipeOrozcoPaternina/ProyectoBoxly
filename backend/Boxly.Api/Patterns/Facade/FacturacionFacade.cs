using Boxly.Api.Models.DTOs;
using Boxly.Api.Models.Entities;
using Boxly.Api.Models.Enums;
using Boxly.Api.Patterns.FactoryMethod;

namespace Boxly.Api.Patterns.Facade;

public record ResultadoPago(bool Aprobado, string TransaccionId, string Mensaje);

/// <summary>
/// Fachada para el patrón Facade (GoF).
/// Unifica el cálculo de planes, la pre-facturación con costos de envío (RN-03)
/// y la validación de la pasarela de pagos en una interfaz limpia.
/// Trazabilidad: RF-10, RF-11, RN-03, RN-04.
/// </summary>
public interface IFacturacionFacade
{
    CotizacionResponseDto LiquidarPreFactura(Caja caja, TipoPlan tipoPlan);
    ResultadoPago ProcesarPagoSimulado(Suscripcion suscripcion, CrearSuscripcionDto dto);
}

public class FacturacionFacade : IFacturacionFacade
{
    public const decimal CostoEnvioFijo = 15000m; // RN-03
    private readonly IPlanFactory _planFactory;
    private readonly ILogger<FacturacionFacade> _logger;

    public FacturacionFacade(IPlanFactory planFactory, ILogger<FacturacionFacade> logger)
    {
        _planFactory = planFactory;
        _logger = logger;
    }

    public CotizacionResponseDto LiquidarPreFactura(Caja caja, TipoPlan tipoPlan)
    {
        var plan = _planFactory.Crear(tipoPlan, caja.PrecioMensual);
        var total = plan.ValorTotal + CostoEnvioFijo;

        return new CotizacionResponseDto
        {
            CajaSlug = caja.Slug,
            CajaNombre = caja.Nombre,
            TipoPlan = plan.Nombre,
            Meses = plan.Meses,
            PorcentajeDescuento = plan.PorcentajeDescuento,
            ValorBruto = plan.ValorBruto,
            ValorAhorro = plan.ValorAhorro,
            ValorPlan = plan.ValorTotal,
            CostoEnvio = CostoEnvioFijo,
            TotalPagar = total,
            EquivalenteMensual = plan.EquivalenteMensual
        };
    }

    public ResultadoPago ProcesarPagoSimulado(Suscripcion suscripcion, CrearSuscripcionDto dto)
    {
        _logger.LogInformation("Procesando pago para la suscripción {Id} por un valor de {Monto} COP", suscripcion.Id, suscripcion.MontoTotal);

        var metodo = (dto.MetodoPago ?? "tarjeta").Trim().ToLowerInvariant();

        if (metodo == "tarjeta")
        {
            var tarjeta = (dto.NumeroTarjeta ?? "").Replace(" ", "").Replace("-", "");

            // Flujo Alternativo: Tarjeta terminada en 0000 o CVV 999 simula fondos insuficientes
            if (tarjeta.EndsWith("0000") || dto.Cvv == "999")
            {
                _logger.LogWarning("Pago RECHAZADO: fondos insuficientes o tarjeta declinada para la suscripción {Id}", suscripcion.Id);
                return new ResultadoPago(false, string.Empty, "La entidad bancaria rechazó la transacción por fondos insuficientes o tarjeta no autorizada.");
            }

            // Flujo Alternativo: Validación de longitud
            if (!string.IsNullOrEmpty(tarjeta) && tarjeta.Length < 13)
            {
                return new ResultadoPago(false, string.Empty, "El número de tarjeta ingresado no cumple con la longitud mínima requerida.");
            }
        }

        // Happy Path: Pago aprobado
        var transaccionId = $"TX-{DateTime.UtcNow:yyyyMMddHHmmss}-{Random.Shared.Next(1000, 9999)}";
        _logger.LogInformation("Pago APROBADO: Transacción {TxId} para la suscripción {Id}", transaccionId, suscripcion.Id);

        return new ResultadoPago(true, transaccionId, "Pago aprobado exitosamente por la pasarela de pagos.");
    }
}
