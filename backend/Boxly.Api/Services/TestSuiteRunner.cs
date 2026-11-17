using Boxly.Api.Models.DTOs;
using Boxly.Api.Models.Enums;
using Boxly.Api.Patterns.Builder;
using Boxly.Api.Patterns.Facade;
using Boxly.Api.Patterns.FactoryMethod;
using Boxly.Api.Repositories;

namespace Boxly.Api.Services;

public static class TestSuiteRunner
{
    public static async Task<int> EjecutarPruebasAsync(IServiceProvider services)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("======================================================================");
        Console.WriteLine(" BOXLY API — SUITE DE VERIFICACIÓN: PATRONES GoF Y FLUJOS ALTERNATIVOS ");
        Console.WriteLine("======================================================================");
        Console.ResetColor();

        int exitosas = 0;
        int fallidas = 0;

        void Reportar(string nombre, bool ok, string detalle = "")
        {
            if (ok)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  [PASS] ");
                Console.ResetColor();
                Console.WriteLine($"{nombre} {(string.IsNullOrEmpty(detalle) ? "" : $"-> {detalle}")}");
                exitosas++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  [FAIL] ");
                Console.ResetColor();
                Console.WriteLine($"{nombre} -> {detalle}");
                fallidas++;
            }
        }

        try
        {
            using var scope = services.CreateScope();
            var planFactory = scope.ServiceProvider.GetRequiredService<IPlanFactory>();
            var cajaBuilder = scope.ServiceProvider.GetRequiredService<ICajaBuilder>();
            var cajaRepo = scope.ServiceProvider.GetRequiredService<ICajaRepository>();
            var suscripcionService = scope.ServiceProvider.GetRequiredService<ISuscripcionService>();
            var facturacionFacade = scope.ServiceProvider.GetRequiredService<IFacturacionFacade>();

            Console.WriteLine("\n-- 1. VERIFICACIÓN DE PATRONES GoF Y REGLAS DE NEGOCIO --");

            // 1.1 Factory Method (RN-11)
            var planMensual = planFactory.Crear(TipoPlan.Mensual, 100000m);
            var planSemestral = planFactory.Crear(TipoPlan.Semestral, 100000m);
            var planAnual = planFactory.Crear(TipoPlan.Anual, 100000m);

            Reportar(
                "Factory Method (RN-11: Descuento Mensual 0%)",
                planMensual.PorcentajeDescuento == 0m && planMensual.ValorTotal == 100000m,
                $"Total: {planMensual.ValorTotal:C0}"
            );
            Reportar(
                "Factory Method (RN-11: Descuento Semestral 10%)",
                planSemestral.PorcentajeDescuento == 0.10m && planSemestral.ValorTotal == 540000m,
                $"Ahorro: {planSemestral.ValorAhorro:C0}, Total: {planSemestral.ValorTotal:C0}"
            );
            Reportar(
                "Factory Method (RN-11: Descuento Anual 20%)",
                planAnual.PorcentajeDescuento == 0.20m && planAnual.ValorTotal == 960000m,
                $"Ahorro: {planAnual.ValorAhorro:C0}, Total: {planAnual.ValorTotal:C0}"
            );

            // 1.2 Builder (RN-05)
            bool builderValidaPrecio = false;
            try
            {
                cajaBuilder.ConIdentificador(99, "test", "Test", "Test").ConPrecios(-10, 5.0).Build();
            }
            catch (ArgumentException)
            {
                builderValidaPrecio = true;
            }
            Reportar("Builder (RN-05: Validación de precios mayores a cero)", builderValidaPrecio);

            // 1.3 Facade (RN-03: Pre-factura = plan + envío de $15.000)
            var cajaGamer = await cajaRepo.ObtenerPorSlugAsync("gamer-ultimate");
            var prefactura = facturacionFacade.LiquidarPreFactura(cajaGamer!, TipoPlan.Mensual);
            Reportar(
                "Facade (RN-03: Pre-factura desglose plan + envío)",
                prefactura.CostoEnvio == 15000m && prefactura.TotalPagar == (prefactura.ValorPlan + 15000m),
                $"Plan: {prefactura.ValorPlan:C0} + Envío: {prefactura.CostoEnvio:C0} = Total: {prefactura.TotalPagar:C0}"
            );

            Console.WriteLine("\n-- 2. VERIFICACIÓN DE FLUJOS PRINCIPALES Y ALTERNATIVOS (MVP) --");

            // 2.1 Flujo Principal: Contratación exitosa (Happy Path 201 -> Estado: Activa)
            var dtoValido = new CrearSuscripcionDto
            {
                CajaSlug = "gamer-ultimate",
                TipoPlan = TipoPlan.Semestral,
                NombreCliente = "Jose Manuel Pulgarin",
                Email = "jose@correo.itm.edu.co",
                Direccion = "Calle 73 # 76A - 354",
                Ciudad = "Medellín",
                Telefono = "3001234567",
                MetodoPago = "tarjeta",
                NumeroTarjeta = "4532000011112222",
                Cvv = "123"
            };

            var resHappy = await suscripcionService.CrearSuscripcionAsync(dtoValido);
            Reportar(
                "Happy Path: Contratación y pago aprobado (RN-04: Estado pasa a Activa)",
                resHappy.Exitoso && resHappy.Datos?.Estado == EstadoSuscripcion.Activa,
                $"Suscripción ID={resHappy.Datos?.Id}, Estado={resHappy.Datos?.Estado}"
            );

            // 2.2 Flujo Alternativo 1: Caja inexistente (404)
            var dtoCajaFalsa = new CrearSuscripcionDto
            {
                CajaSlug = "caja-fantasma-no-existe",
                TipoPlan = TipoPlan.Mensual,
                NombreCliente = "Prueba",
                Email = "test@correo.com",
                Direccion = "Cra 50 # 10",
                Ciudad = "Medellín",
                Telefono = "3001234567"
            };
            var resCajaFalsa = await suscripcionService.CrearSuscripcionAsync(dtoCajaFalsa);
            Reportar(
                "Flujo Alternativo 1: Caja no existente rechazada controladamente (404)",
                !resCajaFalsa.Exitoso && resCajaFalsa.Mensaje.Contains("no fue encontrada"),
                resCajaFalsa.Mensaje
            );

            // 2.3 Flujo Alternativo 2: Tarjeta declinada / fondos insuficientes (422)
            var dtoTarjetaRechazada = new CrearSuscripcionDto
            {
                CajaSlug = "gamer-ultimate",
                TipoPlan = TipoPlan.Mensual,
                NombreCliente = "Jose Manuel",
                Email = "jose@correo.itm.edu.co",
                Direccion = "Calle 73 # 76A",
                Ciudad = "Medellín",
                Telefono = "3001234567",
                MetodoPago = "tarjeta",
                NumeroTarjeta = "4532111122220000", // Termina en 0000 -> Simulación de rechazo bancario
                Cvv = "999"
            };
            var resPagoRechazado = await suscripcionService.CrearSuscripcionAsync(dtoTarjetaRechazada);
            Reportar(
                "Flujo Alternativo 2: Pago declinado por entidad bancaria (RN-04: No activa, queda en PagoRechazado)",
                !resPagoRechazado.Exitoso && resPagoRechazado.Datos?.Estado == EstadoSuscripcion.PagoRechazado,
                $"Estado={resPagoRechazado.Datos?.Estado}, Motivo='{resPagoRechazado.Mensaje}'"
            );

            // 2.4 Flujo Alternativo 3: Cancelación de suscripción
            var idActiva = resHappy.Datos!.Id;
            var resCancel = await suscripcionService.CancelarSuscripcionAsync(idActiva);
            Reportar(
                "Flujo Alternativo 3: Cancelación de suscripción activa por el usuario",
                resCancel.Exitoso && resCancel.Datos?.Estado == EstadoSuscripcion.Cancelada,
                $"Estado actualizado a: {resCancel.Datos?.Estado}"
            );

            // 2.5 Flujo Alternativo 4: Reintento de cancelación de suscripción ya cancelada (400)
            var resReintentoCancel = await suscripcionService.CancelarSuscripcionAsync(idActiva);
            Reportar(
                "Flujo Alternativo 4: Control de idempotencia ante cancelación duplicada",
                !resReintentoCancel.Exitoso && resReintentoCancel.Mensaje.Contains("ya se encuentra en estado cancelado"),
                resReintentoCancel.Mensaje
            );
        }
        catch (Exception ex)
        {
            Reportar("Excepción no controlada durante las pruebas", false, ex.Message);
        }

        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.WriteLine($"RESULTADO FINAL: {exitosas} Pruebas Exitosas | {fallidas} Pruebas Fallidas");
        Console.WriteLine("======================================================================\n");

        return fallidas == 0 ? 0 : 1;
    }
}
