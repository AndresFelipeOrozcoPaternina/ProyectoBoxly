using System.Text.Json.Serialization;
using Boxly.Api.Models.Events;
using Boxly.Api.Patterns.Builder;
using Boxly.Api.Patterns.Facade;
using Boxly.Api.Patterns.FactoryMethod;
using Boxly.Api.Patterns.Strategy;
using Boxly.Api.Repositories;
using Boxly.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Controladores y Serialización JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serializa enums como cadenas de texto legibles (e.g. "Mensual", "Activa")
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Configuración de CORS para permitir peticiones desde Live Server o cliente frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Registro de Patrones de Diseño GoF e Inyección de Dependencias (SOLID)
// 1. Builder (Creacional): Construcción paso a paso de cajas con validaciones
builder.Services.AddTransient<ICajaBuilder, CajaBuilder>();

// 2. Factory Method (Creacional): Creación de variantes de planes sin acoplamiento
builder.Services.AddSingleton<IPlanFactory, PlanFactory>();

// 3. Strategy (Comportamiento): Algoritmo de asignación de productos
builder.Services.AddScoped<IAsignacionStrategy, AsignacionPorAfinidadStrategy>();

// 4. Observer (Comportamiento): Suscriptores para notificación de cambios de estado
builder.Services.AddScoped<ISuscripcionObserver, EmailNotificationObserver>();
builder.Services.AddScoped<ISuscripcionObserver, AuditoriaSuscripcionObserver>();
builder.Services.AddScoped<ISuscripcionNotifier, SuscripcionNotifier>();

// 5. Facade (Estructural): Fachada unificada de pre-facturación y pago
builder.Services.AddScoped<IFacturacionFacade, FacturacionFacade>();

// Repositorios y Servicios de Dominio
builder.Services.AddSingleton<ICajaRepository, InMemoryCajaRepository>();
builder.Services.AddSingleton<ISuscripcionRepository, InMemorySuscripcionRepository>();
builder.Services.AddScoped<ISuscripcionService, SuscripcionService>();

var app = builder.Build();

app.UseCors("CorsFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
