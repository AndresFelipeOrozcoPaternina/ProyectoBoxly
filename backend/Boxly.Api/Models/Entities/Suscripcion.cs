using Boxly.Api.Models.Enums;

namespace Boxly.Api.Models.Entities;

public class Suscripcion
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
    public string CajaSlug { get; set; } = string.Empty;
    public string CajaNombre { get; set; } = string.Empty;
    public TipoPlan TipoPlan { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public string UsuarioEmail { get; set; } = string.Empty;
    public string DireccionEnvio { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string MetodoPago { get; set; } = string.Empty;
    public decimal CostoPlan { get; set; }
    public decimal CostoEnvio { get; set; }
    public decimal MontoTotal { get; set; }
    public EstadoSuscripcion Estado { get; set; } = EstadoSuscripcion.PendientePago;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaActivacion { get; set; }
    public string? MotivoRechazo { get; set; }
}
