using Boxly.Api.Models.DTOs;
using Boxly.Api.Models.Entities;
using Boxly.Api.Repositories;
using Boxly.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Boxly.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CajasController : ControllerBase
{
    private readonly ICajaRepository _cajaRepository;
    private readonly ISuscripcionService _suscripcionService;

    public CajasController(ICajaRepository cajaRepository, ISuscripcionService suscripcionService)
    {
        _cajaRepository = cajaRepository;
        _suscripcionService = suscripcionService;
    }

    /// <summary>
    /// Consulta el catálogo completo de cajas de suscripción disponibles.
    /// Flujo principal (HU-1.1, HU-1.2).
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Caja>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerCatalogo()
    {
        var cajas = await _cajaRepository.ObtenerTodasAsync();
        return Ok(cajas);
    }

    /// <summary>
    /// Consulta el detalle de una caja por su slug.
    /// Flujo principal y flujo alternativo de recurso inexistente (HU-1.3).
    /// </summary>
    [HttpGet("{slug}")]
    [ProducesResponseType(typeof(Caja), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObtenerPorSlug(string slug)
    {
        var caja = await _cajaRepository.ObtenerPorSlugAsync(slug);
        if (caja == null)
        {
            // Flujo Alternativo: 404 Not Found
            return NotFound(ResultadoOperacionDto<object>.Fallo(
                $"No se encontró ninguna caja con el slug '{slug}'."
            ));
        }

        return Ok(caja);
    }

    /// <summary>
    /// Liquida la prefactura de una caja según el plan seleccionado (Mensual, Semestral, Anual).
    /// Aplica descuentos RN-11 y costo de envío fijo RN-03.
    /// </summary>
    [HttpPost("cotizar")]
    [ProducesResponseType(typeof(ResultadoOperacionDto<CotizacionResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cotizar([FromBody] CotizacionRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.CajaSlug))
        {
            // Flujo Alternativo: 400 Bad Request
            return BadRequest(ResultadoOperacionDto<object>.Fallo("El parámetro 'CajaSlug' es obligatorio para cotizar."));
        }

        var resultado = await _suscripcionService.CotizarAsync(dto.CajaSlug, dto.TipoPlan);
        if (!resultado.Exitoso)
        {
            // Flujo Alternativo: 404 Not Found
            return NotFound(resultado);
        }

        return Ok(resultado);
    }
}
