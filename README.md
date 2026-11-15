# ProyectoBoxly — Plataforma SaaS de Cajas de Suscripción

Plataforma integral de gestión y contratación de cajas de suscripción temáticas (Gaming, Fitness, Cuidado Personal y Tecnología). Desarrollado para el curso de **Diseño de Sistemas de Información** del **Instituto Tecnológico de Medellín (ITM)** — **Entregable No. 3**.

---

## 🛠️ Tecnologías y Arquitectura

* **Backend:** ASP.NET Core Web API (.NET 10 / C#) con arquitectura limpia multicapa, Inyección de Dependencias nativa (`Microsoft.Extensions.DependencyInjection`), controladores RESTful y serialización JSON.
* **Frontend:** HTML5 semántico, CSS3 corporativo (Dark Mode responsivo) y JavaScript vanilla modular con comunicación asíncrona (`fetch`) y fallback resiliente en `localStorage`.
* **Patrones GoF implementados:**
  1. **Factory Method (Creacional):** Creación polimórfica de planes (*Mensual*, *Semestral* con 10% de descuento, *Anual* con 20% de descuento) cumpliendo **RN-11** (`PlanFactory.cs`).
  2. **Builder (Creacional):** Construcción y validación paso a paso de objetos complejos `Caja` con reglas de negocio de stock y precios mayores a cero (**RN-05**, `CajaBuilder.cs`).
  3. **Strategy (Comportamiento):** Algoritmos intercambiables de selección y asignación de productos por afinidad del usuario (**RN-05, RN-06**, `AsignacionStrategy.cs`).
  4. **Observer (Comportamiento):** Desacoplamiento de eventos para notificaciones por correo y bitácora de auditoría ante cambios en el ciclo de vida de la suscripción (**RF-13, RN-08**, `SuscripcionObserver.cs`).
  5. **Facade (Estructural):** Fachada unificada que consolida la pre-facturación con costo fijo de envío (**RN-03**) y la pasarela de pagos simulada (`FacturacionFacade.cs`).
* **Principios SOLID:** Responsabilidad Única (SRP), Abierto/Cerrado (OCP), Sustitución de Liskov (LSP), Segregación de Interfaces (ISP) e Inversión de Dependencias (DIP) aplicados en toda la capa de dominio y repositorios.

---

## 🚀 Cómo ejecutar el proyecto (Frontend + Backend)

### 1. Prerrequisitos
* **.NET 10 SDK** (o runtime de .NET instalado).
* Navegador web moderno (Chrome, Firefox, Edge).
* Opcional: Extensión **Live Server** en VS Code.

### 2. Iniciar el Backend API
En la terminal, ejecuta:
```bash
dotnet run --project backend/Boxly.Api --urls "http://localhost:5000"
```
> La API quedará escuchando en `http://localhost:5000` con CORS habilitado para admitir peticiones desde el frontend.

### 3. Ejecutar la Suite de Verificación Automatizada (Tests de GoF y Flujos Alternativos)
Para verificar en consola la ejecución exitosa de los 5 patrones GoF, reglas de negocio y flujos alternativos:
```bash
dotnet run --project backend/Boxly.Api -- --verify-suite
```
> Ejecuta 10 pruebas automatizadas sin dependencias externas reportando el estado `[PASS]` / `[FAIL]` de cada regla y flujo.

### 4. Abrir el Frontend
Abre directamente `front/inicio.html` en tu navegador o ejecuta Live Server sobre la carpeta `front/`.

**Happy Path del MVP navegable:**
1. **`front/inicio.html`** — Catálogo interactivo con filtros por categoría (Gaming, Fitness, Cuidado Personal, Tecnología).
2. **`front/detalle.html`** — Detalle de la caja, inclusión de ítems y selector de periodicidad (Mensual, Semestral -10%, Anual -20%).
3. **`front/facturacion.html`** — Formulario de envío, método de pago y pre-factura en tiempo real (Plan + Envío = Total).
   * *Happy Path:* Deja la tarjeta de prueba predeterminada y haz clic en "Confirmar pre-factura" ➔ La suscripción se activa con HTTP 201 (**RN-04**).
   * *Flujo Alternativo:* Ingresa una tarjeta terminada en **0000** o CVV **999** ➔ El backend responde con HTTP 422 (Unprocessable Entity) y la interfaz muestra la alerta bancaria de fondos insuficientes sin activar la suscripción (**RN-04**).
4. **`front/cajas.html`** — Panel "Mis cajas" con filtros por estado (*Activa*, *Próxima*, *Cancelada*). Incluye modal con botón para **Cancelar suscripción** (Flujo alternativo de ciclo de vida).
5. **`front/configuracion.html`** — Gestión de perfil, preferencias e intereses, métricas y cierre de sesión.

---

## 📡 Catálogo de Endpoints REST y Flujos Alternativos

| Método | Endpoint | Código HTTP | Descripción y Flujo |
| :--- | :--- | :--- | :--- |
| `GET` | `/api/cajas` | `200 OK` | Catálogo completo de cajas de suscripción disponibles. |
| `GET` | `/api/cajas/{slug}` | `200 OK` | Detalle de la caja solicitada. |
| `GET` | `/api/cajas/{slug}` | `404 Not Found` | **Flujo Alternativo:** Caja no encontrada en el catálogo. |
| `POST` | `/api/cajas/cotizar` | `200 OK` | Liquidación de pre-factura con descuentos según **RN-11** y costo de envío fijo (**RN-03**). |
| `POST` | `/api/cajas/cotizar` | `400 Bad Request` | **Flujo Alternativo:** Parámetros obligatorios faltantes. |
| `POST` | `/api/suscripciones` | `201 Created` | **Flujo Principal (Happy Path):** Pago aprobado, suscripción activada (**RN-04**). |
| `POST` | `/api/suscripciones` | `400 Bad Request` | **Flujo Alternativo:** Errores de validación en datos de cliente o dirección. |
| `POST` | `/api/suscripciones` | `404 Not Found` | **Flujo Alternativo:** Intento de suscripción a una caja inexistente. |
| `POST` | `/api/suscripciones` | `409 Conflict` | **Flujo Alternativo:** Sin existencias disponibles (stock agotado). |
| `POST` | `/api/suscripciones` | `422 Unprocessable` | **Flujo Alternativo:** Pago declinado por fondos insuficientes. La suscripción queda en `PagoRechazado` y **no se activa** (**RN-04**). |
| `GET` | `/api/suscripciones` | `200 OK` | Consulta del listado de suscripciones del usuario. |
| `GET` | `/api/suscripciones/{id}` | `200 OK` / `404 Not Found` | Detalle de suscripción por identificador. |
| `POST` | `/api/suscripciones/{id}/cancelar` | `200 OK` | **Flujo Alternativo:** Cancelación de suscripción activa. |
| `POST` | `/api/suscripciones/{id}/cancelar` | `400 Bad Request` | **Flujo Alternativo:** Control de idempotencia (intento de cancelar suscripción ya cancelada). |

---

## 📂 Estructura del Repositorio

```text
ProyectoBoxly/
├── backend/
│   └── Boxly.Api/                     # Backend Web API en ASP.NET Core
│       ├── Controllers/               # CajasController y SuscripcionesController
│       ├── Models/                    # Entidades (Caja, Plan, Suscripcion), Enums y DTOs
│       ├── Patterns/                  # Implementación de los 5 patrones GoF
│       │   ├── Builder/               # CajaBuilder (RN-05)
│       │   ├── Facade/                # FacturacionFacade (RN-03, RN-04)
│       │   ├── FactoryMethod/         # PlanFactory y variantes (RN-11)
│       │   ├── Observer/              # EmailNotifier y AuditoriaObserver (RF-13, RN-08)
│       │   └── Strategy/              # AsignacionPorAfinidadStrategy (RN-05, RN-06)
│       ├── Repositories/              # Repositorios en memoria y abstracciones
│       ├── Services/                  # SuscripcionService y TestSuiteRunner
│       └── Program.cs                 # Pipeline HTTP, CORS y contenedor DI
├── front/                             # Prototipo web frontend
│   ├── css/estilos.css                # Hoja de estilos compartidos y paleta corporativa
│   ├── js/script.js                   # Lógica de consumo de API REST y persistencia
│   ├── inicio.html                    # Catálogo con filtros por categoría
│   ├── detalle.html                   # Vista de detalle y selección de planes
│   ├── facturacion.html               # Formulario de checkout y prefactura
│   ├── cajas.html                     # Panel 'Mis cajas' y cancelación
│   ├── configuracion.html             # Configuración y cierre de sesión
│   ├── bonos.html                     # Programa de bonos y recompensas
│   ├── login.html                     # Acceso al sistema
│   └── registro.html                  # Registro de usuario
├── diagramas/                         # Diagramas de actividades (.drawio y .svg)
├── Documentacion/                     # Entregables 1, 2 y 3 en Markdown y anexos GoF/SOLID
├── Imagenes/                          # Recursos gráficos locales
└── README.md                          # Guía técnica y de ejecución
```

---

## 👥 Equipo de Trabajo

* **Andrés Felipe Orozco Paternina**
* **Jose Manuel Pulgarin Rueda**
* **Juan David Restrepo Alvarez**
* **Jesús David Ávila Arrieta**

**Docente:** Alexandra Guerrero Bocanegra — Instituto Tecnológico de Medellín (ITM), 2026.
