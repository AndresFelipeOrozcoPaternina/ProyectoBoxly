using Boxly.Api.Models.Entities;

namespace Boxly.Api.Patterns.Strategy;

/// <summary>
/// Interfaz para el patrón Strategy (GoF).
/// Permite intercambiar dinámicamente el algoritmo de selección y personalización de ítems en la caja.
/// Trazabilidad: RF-04, RN-05, RN-06.
/// </summary>
public interface IAsignacionStrategy
{
    string NombreEstrategia { get; }
    List<string> AsignarProductos(Caja caja, string? perfilIntereses);
}

public class AsignacionEstandarStrategy : IAsignacionStrategy
{
    public string NombreEstrategia => "Estándar por Catálogo";

    public List<string> AsignarProductos(Caja caja, string? perfilIntereses)
    {
        return new List<string>(caja.Inclusiones);
    }
}

public class AsignacionPorAfinidadStrategy : IAsignacionStrategy
{
    public string NombreEstrategia => "Personalización por Afinidad";

    public List<string> AsignarProductos(Caja caja, string? perfilIntereses)
    {
        var lista = new List<string>(caja.Inclusiones);

        if (!string.IsNullOrWhiteSpace(perfilIntereses))
        {
            // Agrega ítem especial personalizado si el usuario configuró intereses
            lista.Add($"Ítem sorpresa personalizado afinidad ({perfilIntereses.Trim()})");
        }

        return lista;
    }
}
