using Boxly.Api.Models.Enums;

namespace Boxly.Api.Models.DTOs;

public class CotizacionRequestDto
{
    public string CajaSlug { get; set; } = string.Empty;
    public TipoPlan TipoPlan { get; set; } = TipoPlan.Mensual;
}

public class CotizacionResponseDto
{
    public string CajaSlug { get; set; } = string.Empty;
    public string CajaNombre { get; set; } = string.Empty;
    public string TipoPlan { get; set; } = string.Empty;
    public int Meses { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public decimal ValorBruto { get; set; }
    public decimal ValorAhorro { get; set; }
    public decimal ValorPlan { get; set; }
    public decimal CostoEnvio { get; set; }
    public decimal TotalPagar { get; set; }
    public decimal EquivalenteMensual { get; set; }
}
