using System.ComponentModel.DataAnnotations;
using Boxly.Api.Models.Enums;

namespace Boxly.Api.Models.DTOs;

public class CrearSuscripcionDto
{
    [Required(ErrorMessage = "La caja seleccionada es obligatoria.")]
    public string CajaSlug { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de plan es obligatorio.")]
    public TipoPlan TipoPlan { get; set; } = TipoPlan.Mensual;

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La dirección de envío es obligatoria.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe ser clara y detallada (mínimo 5 caracteres).")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "La ciudad es obligatoria.")]
    public string Ciudad { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono de contacto es obligatorio.")]
    [Phone(ErrorMessage = "El formato de teléfono no es válido.")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El método de pago es obligatorio.")]
    public string MetodoPago { get; set; } = "tarjeta";

    // Campos de pago simulado
    public string? NumeroTarjeta { get; set; }
    public string? Cvv { get; set; }
    public string? FechaVencimiento { get; set; }
}
