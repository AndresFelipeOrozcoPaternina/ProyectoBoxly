using Boxly.Api.Models.DTOs;
using Boxly.Api.Models.Entities;
using Boxly.Api.Models.Enums;
using Boxly.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Boxly.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuscripcionesController : ControllerBase
{
    private readonly ISuscripcionService _suscripcionService;
    private readonly ILogger<SuscripcionesController> _logger;

    public SuscripcionesController(ISuscripcionService suscripcionService, ILogger<SuscripcionesController> logger)
    {
        _suscripcionService = suscripcionService;
        _logger = logger;
    }

    /// <summary>
    /// Consulta el listado de suscripciones registradas (Panel 'Mis Cajas').
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Suscripcion>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerTodas()
    {
        var suscripciones = await _suscripcionService.ObtenerSuscripcionesAsync();
        return Ok(suscripciones);
    }

    /// <summary>
    /// Consulta el detalle de una suscripción por su ID de referencia.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Suscripcion), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObtenerPorId(string id)
    {
        var suscripcion = await _suscripcionService.ObtenerPorIdAsync(id);
        if (suscripcion == null)
        {
            // Flujo Alternativo: 404 Not Found
            return NotFound(ResultadoOperacionDto<object>.Fallo(
                $"No se encontró ninguna suscripción con el identificador '{id}'."
            ));
        }

        return Ok(suscripcion);
    }

    /// <summary>
    /// Procesa y contrata una nueva suscripción con validación de reglas de negocio y pasarela de pago.
    /// Soporta Happy Path (201 Created) y Flujos Alternativos (400 Bad Request, 404 Not Found, 409 Conflict, 422 Unprocessable).
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ResultadoOperacionDto<Suscripcion>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<Suscripcion>), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CrearSuscripcion([FromBody] CrearSuscripcionDto dto)
    {
        // Flujo Alternativo 1: Validación de datos de entrada (400 Bad Request)
        if (!ModelState.IsValid)
        {
            var errores = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            _logger.LogWarning("Datos de suscripción inválidos: {Errores}", string.Join(", ", errores));
            return BadRequest(ResultadoOperacionDto<object>.Fallo("Errores en los datos de la solicitud.", errores));
        }

        var resultado = await _suscripcionService.CrearSuscripcionAsync(dto);

        // Flujo Alternativo 2: Caja inexistente (404 Not Found)
        if (!resultado.Exitoso && resultado.Mensaje.Contains("no fue encontrada", StringComparison.OrdinalIgnoreCase))
        {
            return NotFound(resultado);
        }

        // Flujo Alternativo 3: Sin existencias disponibles (409 Conflict)
        if (!resultado.Exitoso && resultado.Mensaje.Contains("existencias disponibles", StringComparison.OrdinalIgnoreCase))
        {
            return Conflict(resultado);
        }

        // Flujo Alternativo 4: Pago rechazado por la pasarela (422 Unprocessable Entity)
        if (!resultado.Exitoso && resultado.Datos?.Estado == EstadoSuscripcion.PagoRechazado)
        {
            return UnprocessableEntity(resultado);
        }

        // Flujo Principal (Happy Path): 201 Created con suscripción activa (RN-04)
        return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Datos!.Id }, resultado);
    }

    /// <summary>
    /// Cancela una suscripción activa (Flujo alternativo del ciclo de vida).
    /// </summary>
    [HttpPost("{id}/cancelar")]
    [ProducesResponseType(typeof(ResultadoOperacionDto<Suscripcion>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoOperacionDto<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelarSuscripcion(string id)
    {
        var resultado = await _suscripcionService.CancelarSuscripcionAsync(id);

        if (!resultado.Exitoso)
        {
            if (resultado.Mensaje.Contains("No se encontró", StringComparison.OrdinalIgnoreCase))
            {
                // Flujo Alternativo: 404 Not Found
                return NotFound(resultado);
            }

            // Flujo Alternativo: 400 Bad Request (ya cancelada)
            return BadRequest(resultado);
        }

        return Ok(resultado);
    }
}
