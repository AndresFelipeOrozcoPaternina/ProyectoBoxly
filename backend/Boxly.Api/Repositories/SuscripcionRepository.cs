using System.Collections.Concurrent;
using Boxly.Api.Models.Entities;

namespace Boxly.Api.Repositories;

public interface ISuscripcionRepository
{
    Task<IEnumerable<Suscripcion>> ObtenerTodasAsync();
    Task<Suscripcion?> ObtenerPorIdAsync(string id);
    Task GuardarAsync(Suscripcion suscripcion);
    Task ActualizarAsync(Suscripcion suscripcion);
}

public class InMemorySuscripcionRepository : ISuscripcionRepository
{
    private readonly ConcurrentDictionary<string, Suscripcion> _almacen = new();

    public Task<IEnumerable<Suscripcion>> ObtenerTodasAsync()
    {
        return Task.FromResult<IEnumerable<Suscripcion>>(_almacen.Values.OrderByDescending(s => s.FechaCreacion));
    }

    public Task<Suscripcion?> ObtenerPorIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return Task.FromResult<Suscripcion?>(null);

        _almacen.TryGetValue(id.Trim().ToUpperInvariant(), out var suscripcion);
        return Task.FromResult(suscripcion);
    }

    public Task GuardarAsync(Suscripcion suscripcion)
    {
        _almacen[suscripcion.Id.ToUpperInvariant()] = suscripcion;
        return Task.CompletedTask;
    }

    public Task ActualizarAsync(Suscripcion suscripcion)
    {
        _almacen[suscripcion.Id.ToUpperInvariant()] = suscripcion;
        return Task.CompletedTask;
    }
}
