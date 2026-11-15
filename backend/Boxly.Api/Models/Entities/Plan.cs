using Boxly.Api.Models.Enums;

namespace Boxly.Api.Models.Entities;

public class Plan
{
    public TipoPlan Tipo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Meses { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public decimal ValorBruto { get; set; }
    public decimal ValorAhorro { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal EquivalenteMensual { get; set; }
}
