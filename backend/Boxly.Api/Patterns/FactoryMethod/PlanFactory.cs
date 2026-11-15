using Boxly.Api.Models.Entities;
using Boxly.Api.Models.Enums;

namespace Boxly.Api.Patterns.FactoryMethod;

/// <summary>
/// Creator abstracto para el patrón Factory Method (GoF).
/// Permite instanciar y calcular variantes de planes sin acoplar la lógica de negocio a condicionales rígidos.
/// Trazabilidad: RF-08, RF-17, RN-11.
/// </summary>
public abstract class PlanCreator
{
    public abstract TipoPlan Tipo { get; }
    public abstract Plan CrearPlan(decimal precioMensual);
}

public class PlanMensualCreator : PlanCreator
{
    public override TipoPlan Tipo => TipoPlan.Mensual;

    public override Plan CrearPlan(decimal precioMensual)
    {
        return new Plan
        {
            Tipo = TipoPlan.Mensual,
            Nombre = "Mensual",
            Meses = 1,
            PorcentajeDescuento = 0.00m,
            ValorBruto = precioMensual,
            ValorAhorro = 0,
            ValorTotal = precioMensual,
            EquivalenteMensual = precioMensual
        };
    }
}

public class PlanSemestralCreator : PlanCreator
{
    public override TipoPlan Tipo => TipoPlan.Semestral;

    public override Plan CrearPlan(decimal precioMensual)
    {
        const int meses = 6;
        const decimal descuento = 0.10m; // 10% de descuento (RN-11)
        var bruto = precioMensual * meses;
        var ahorro = Math.Round(bruto * descuento, 0);
        var total = bruto - ahorro;

        return new Plan
        {
            Tipo = TipoPlan.Semestral,
            Nombre = "Semestral",
            Meses = meses,
            PorcentajeDescuento = descuento,
            ValorBruto = bruto,
            ValorAhorro = ahorro,
            ValorTotal = total,
            EquivalenteMensual = Math.Round(total / meses, 0)
        };
    }
}

public class PlanAnualCreator : PlanCreator
{
    public override TipoPlan Tipo => TipoPlan.Anual;

    public override Plan CrearPlan(decimal precioMensual)
    {
        const int meses = 12;
        const decimal descuento = 0.20m; // 20% de descuento (RN-11)
        var bruto = precioMensual * meses;
        var ahorro = Math.Round(bruto * descuento, 0);
        var total = bruto - ahorro;

        return new Plan
        {
            Tipo = TipoPlan.Anual,
            Nombre = "Anual",
            Meses = meses,
            PorcentajeDescuento = descuento,
            ValorBruto = bruto,
            ValorAhorro = ahorro,
            ValorTotal = total,
            EquivalenteMensual = Math.Round(total / meses, 0)
        };
    }
}

public interface IPlanFactory
{
    Plan Crear(TipoPlan tipo, decimal precioMensual);
}

public class PlanFactory : IPlanFactory
{
    private readonly Dictionary<TipoPlan, PlanCreator> _creators = new()
    {
        { TipoPlan.Mensual, new PlanMensualCreator() },
        { TipoPlan.Semestral, new PlanSemestralCreator() },
        { TipoPlan.Anual, new PlanAnualCreator() }
    };

    public Plan Crear(TipoPlan tipo, decimal precioMensual)
    {
        if (!_creators.TryGetValue(tipo, out var creator))
        {
            creator = _creators[TipoPlan.Mensual];
        }

        return creator.CrearPlan(precioMensual);
    }
}
