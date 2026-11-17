using Boxly.Api.Models.Entities;

namespace Boxly.Api.Patterns.Builder;

/// <summary>
/// Interfaz para el patrón Builder (GoF).
/// Permite construir objetos complejos Caja paso a paso garantizando validaciones de dominio.
/// Trazabilidad: RF-04, RF-18, RN-05.
/// </summary>
public interface ICajaBuilder
{
    ICajaBuilder ConIdentificador(int id, string slug, string nombre, string categoria);
    ICajaBuilder ConPrecios(decimal precioMensual, double rating);
    ICajaBuilder ConDetalles(string imagenUrl, string descripcion);
    ICajaBuilder AgregarInclusion(string item);
    ICajaBuilder ConStock(int stock);
    Caja Build();
}

public class CajaBuilder : ICajaBuilder
{
    private Caja _caja = new();

    public CajaBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _caja = new Caja();
    }

    public ICajaBuilder ConIdentificador(int id, string slug, string nombre, string categoria)
    {
        _caja.Id = id;
        _caja.Slug = slug.Trim().ToLowerInvariant();
        _caja.Nombre = nombre.Trim();
        _caja.Categoria = categoria.Trim();
        return this;
    }

    public ICajaBuilder ConPrecios(decimal precioMensual, double rating)
    {
        if (precioMensual <= 0)
            throw new ArgumentException("El precio mensual de la caja debe ser mayor a cero.");

        _caja.PrecioMensual = precioMensual;
        _caja.Rating = rating;
        return this;
    }

    public ICajaBuilder ConDetalles(string imagenUrl, string descripcion)
    {
        _caja.ImagenUrl = imagenUrl;
        _caja.Descripcion = descripcion;
        return this;
    }

    public ICajaBuilder AgregarInclusion(string item)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            _caja.Inclusiones.Add(item.Trim());
        }
        return this;
    }

    public ICajaBuilder ConStock(int stock)
    {
        _caja.StockDisponible = Math.Max(0, stock);
        return this;
    }

    public Caja Build()
    {
        if (string.IsNullOrEmpty(_caja.Slug))
            throw new InvalidOperationException("La caja debe tener un slug identificador válido.");

        if (string.IsNullOrEmpty(_caja.Nombre))
            throw new InvalidOperationException("La caja debe tener un nombre.");

        if (_caja.Inclusiones.Count < 2)
            throw new InvalidOperationException("Una caja temática debe incluir al menos 2 ítems para ser válida.");

        var resultado = _caja;
        Reset();
        return resultado;
    }
}
