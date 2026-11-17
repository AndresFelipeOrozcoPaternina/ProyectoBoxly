using Boxly.Api.Models.Entities;
using Boxly.Api.Patterns.Builder;

namespace Boxly.Api.Repositories;

public interface ICajaRepository
{
    Task<IEnumerable<Caja>> ObtenerTodasAsync();
    Task<Caja?> ObtenerPorSlugAsync(string slug);
}

public class InMemoryCajaRepository : ICajaRepository
{
    private readonly List<Caja> _cajas;

    public InMemoryCajaRepository(ICajaBuilder builder)
    {
        _cajas = new List<Caja>
        {
            builder.ConIdentificador(1, "gamer-ultimate", "Caja gamer ultimate", "Gaming")
                .ConPrecios(135000, 4.8)
                .ConDetalles(
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRoPr61I1wZ9vVp-bfg2llh6Kd_MOY3qx7Y9vqLg1ZC4A&s=10",
                    "La caja definitiva para amantes del gaming: accesorios, merchandising y snacks seleccionados cada mes para vivir la experiencia completa de tus lanzamientos favoritos."
                )
                .AgregarInclusion("Mousepad XL de edición")
                .AgregarInclusion("Figura coleccionable")
                .AgregarInclusion("Snacks gamer premium")
                .AgregarInclusion("Accesorio USB sorpresa")
                .AgregarInclusion("Stickers exclusivos")
                .ConStock(15)
                .Build(),

            builder.ConIdentificador(2, "fitbox-mensual", "Fitbox mensual", "Fitness")
                .ConPrecios(120000, 4.8)
                .ConDetalles(
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqZD1C6DElaUq8b3KQZa9OWRSltXfvpCLpLhW3Bk2Avg&s=10",
                    "Kit mensual con suplementos, accesorios deportivos y elementos para entrenar en casa o en el gimnasio con mayor comodidad, seguridad y variedad."
                )
                .AgregarInclusion("Suplemento o pre-entreno")
                .AgregarInclusion("Botella deportiva")
                .AgregarInclusion("Bandas de resistencia")
                .AgregarInclusion("Snacks proteicos")
                .AgregarInclusion("Guías de entrenamiento")
                .ConStock(25)
                .Build(),

            builder.ConIdentificador(3, "cuidado-bienestar", "Cuidado y bienestar", "Cuidado personal")
                .ConPrecios(120000, 4.8)
                .ConDetalles(
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4hlipP6Nzf61W2_VHdRVjMIqjkZiMuyCTW3o67RSCrQ&s=10",
                    "Productos de higiene, cuidado personal y bienestar para mantener una rutina completa cada mes con artículos premium y útiles de uso diario."
                )
                .AgregarInclusion("Exfoliante corporal")
                .AgregarInclusion("Vela aromática")
                .AgregarInclusion("Mascarilla facial")
                .AgregarInclusion("Aceite esencial")
                .AgregarInclusion("Té relajante")
                .ConStock(30)
                .Build(),

            builder.ConIdentificador(4, "techbox-premium", "Techbox premium", "Tecnología")
                .ConPrecios(200000, 4.9)
                .ConDetalles(
                    "https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=900&q=80",
                    "Suscripción con gadgets, accesorios y productos tecnológicos para potenciar tu espacio digital y mantenerte al día con cada lanzamiento del mundo tech."
                )
                .AgregarInclusion("Power bank 10.000 mAh")
                .AgregarInclusion("Cable USB-C premium")
                .AgregarInclusion("Soporte de celular")
                .AgregarInclusion("Hub USB compacto")
                .AgregarInclusion("Stickers tech")
                .ConStock(8)
                .Build()
        };
    }

    public Task<IEnumerable<Caja>> ObtenerTodasAsync()
    {
        return Task.FromResult<IEnumerable<Caja>>(_cajas.Where(c => c.Activa));
    }

    public Task<Caja?> ObtenerPorSlugAsync(string slug)
    {
        var normalizado = (slug ?? string.Empty).Trim().ToLowerInvariant();
        var caja = _cajas.FirstOrDefault(c => c.Slug == normalizado);
        return Task.FromResult(caja);
    }
}
