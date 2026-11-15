using Boxly.Api.Models.Entities;
using Boxly.Api.Models.Enums;

namespace Boxly.Api.Models.Events;

/// <summary>
/// Evento emitido al cambiar el estado del ciclo de vida de una suscripción.
/// Base del patrón Observer (GoF).
/// Trazabilidad: RF-13, RN-08.
/// </summary>
public record EstadoSuscripcionCambiadoEvent(
    Suscripcion Suscripcion,
    EstadoSuscripcion EstadoAnterior,
    EstadoSuscripcion EstadoNuevo,
    string Detalle,
    DateTime Timestamp
);

public interface ISuscripcionObserver
{
    Task NotificarAsync(EstadoSuscripcionCambiadoEvent evento);
}

public interface ISuscripcionNotifier
{
    void RegistrarObserver(ISuscripcionObserver observer);
    Task NotificarCambioEstadoAsync(Suscripcion suscripcion, EstadoSuscripcion anterior, string detalle);
}

public class EmailNotificationObserver : ISuscripcionObserver
{
    private readonly ILogger<EmailNotificationObserver> _logger;

    public EmailNotificationObserver(ILogger<EmailNotificationObserver> logger)
    {
        _logger = logger;
    }

    public Task NotificarAsync(EstadoSuscripcionCambiadoEvent evento)
    {
        _logger.LogInformation(
            "[EmailNotifier] Correo enviado a {Email} para la suscripción {Id}: Estado pasó de {Anterior} a {Nuevo}. Detalle: {Detalle}",
            evento.Suscripcion.UsuarioEmail,
            evento.Suscripcion.Id,
            evento.EstadoAnterior,
            evento.EstadoNuevo,
            evento.Detalle
        );

        return Task.CompletedTask;
    }
}

public class AuditoriaSuscripcionObserver : ISuscripcionObserver
{
    private readonly ILogger<AuditoriaSuscripcionObserver> _logger;

    public AuditoriaSuscripcionObserver(ILogger<AuditoriaSuscripcionObserver> logger)
    {
        _logger = logger;
    }

    public Task NotificarAsync(EstadoSuscripcionCambiadoEvent evento)
    {
        _logger.LogInformation(
            "[Auditoría] Transición registrada en la bitácora: Suscripción={Id}, De={Anterior}, A={Nuevo}, Timestamp={Fecha}",
            evento.Suscripcion.Id,
            evento.EstadoAnterior,
            evento.EstadoNuevo,
            evento.Timestamp
        );

        return Task.CompletedTask;
    }
}

public class SuscripcionNotifier : ISuscripcionNotifier
{
    private readonly List<ISuscripcionObserver> _observers = new();

    public SuscripcionNotifier(IEnumerable<ISuscripcionObserver> observers)
    {
        _observers.AddRange(observers);
    }

    public void RegistrarObserver(ISuscripcionObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public async Task NotificarCambioEstadoAsync(Suscripcion suscripcion, EstadoSuscripcion anterior, string detalle)
    {
        var evento = new EstadoSuscripcionCambiadoEvent(
            suscripcion,
            anterior,
            suscripcion.Estado,
            detalle,
            DateTime.UtcNow
        );

        foreach (var observer in _observers)
        {
            await observer.NotificarAsync(evento);
        }
    }
}
