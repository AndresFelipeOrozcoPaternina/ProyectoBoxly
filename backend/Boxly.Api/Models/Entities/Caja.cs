namespace Boxly.Api.Models.Entities;

public class Caja
{
    public int Id { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal PrecioMensual { get; set; }
    public double Rating { get; set; }
    public string ImagenUrl { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public List<string> Inclusiones { get; set; } = new();
    public bool Activa { get; set; } = true;
    public int StockDisponible { get; set; } = 50;
}
