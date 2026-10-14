# ProyectoBoxly

Prototipo funcional de **Boxly**, plataforma SaaS de gestión y contratación de cajas de suscripción temáticas (Gaming, Fitness, Cuidado Personal, Tecnología). Desarrollado para el curso de **Diseño de Sistemas de Información** del Instituto Tecnológico de Medellín (ITM) — Entregable No. 2.

## Cómo ejecutar el prototipo

No requiere instalación ni compilación. Abre `inicio.html` en cualquier navegador moderno (o ejecuta el proyecto mediante **Live Server** en VS Code) y navega el Happy Path:

1. **`inicio.html`** — Catálogo general con filtros por categoría (HU-1.1, HU-1.2).
2. **`detalle.html`** — Detalle de la caja y selección de plan Mensual / Semestral (−10 %) / Anual (−20 %) (HU-1.3).
3. **`facturacion.html`** — Dirección de envío, método de pago y pre-factura con desglose plan + envío = total (HU-3.1, RN-03).
4. **`cajas.html`** — Panel «Mis cajas»: la suscripción confirmada aparece como **Activa**.
5. **`configuracion.html`** — Sección de configuración de cuenta: gestión de datos personales (RF-03), selección de intereses y preferencias (RF-04), visualización de métricas de usuario y función para **cerrar sesión** con redirección a `login.html`.

Páginas complementarias: `registro.html` (HU-2.1), `login.html` (HU-2.2), `bonos.html` (programa de recompensas).

## Estructura del repositorio

| Archivo / carpeta | Descripción |
| --- | --- |
| `inicio.html`, `detalle.html`, `facturacion.html`, `cajas.html` | Flujo principal del MVP |
| `configuracion.html` | Configuración de perfil, preferencias, estadísticas y cierre de sesión (RF-03, RF-04) |
| `registro.html`, `login.html` | Autenticación y acceso al sistema (RN-01) |
| `bonos.html` + `bonos_1.jpeg`, `bonos_2.jpeg` | Programa de bonos y recompensas |
| `estilos.css`, `script.js` | Estilos compartidos, paleta de colores corporativa y lógica del prototipo |
| `diagramas/` | Diagramas de actividades del MVP (`.drawio` editables + `.svg`) |
| `Arquitectura C4.md` | Documento técnico del Entregable No. 2 |
| `Entregable_1.pdf`, `Entregable_2.pdf` | Entregables del curso |

## Diagramas C4 
A continuación se presentan los diagramas arquitectónicos de la plataforma de suscripción de cajas Boxly, estructurados según los cuatro niveles del Modelo C4.

## C1: Nivel 1 - Diagrama de Contexto

Este nivel muestra la plataforma Boxly como una caja negra y cómo interactúa con sus usuarios principales (Cliente y Administrador) y con los sistemas externos (Servicio SMTP).

```mermaid
graph TD
    U["Cliente / Usuario Suscriptor<br/>[Actor]"]
    A["Administrador<br/>[Actor]"]
    P["Plataforma BOXLY<br/>[Sistema .NET]"]
    S["Servicio de Notificaciones SMTP<br/>[Externo]"]

    U -->|"Explora catálogo y gestiona suscripciones"| P
    A -->|"Gestiona inventario, cajas y validación de pagos"| P
    P -->|"Envía notificaciones y pre-facturas"| S

    %% Estilos
    style U fill:#4a86e8,color:#fff,stroke:#4a86e8
    style A fill:#4a86e8,color:#fff,stroke:#4a86e8
    style P fill:#5b46f6,color:#fff,stroke:#5b46f6
    style S fill:#fff,stroke:#333,color:#000
```

---

## C2: Nivel 2 - Diagrama de Contenedores

Este nivel abre la "caja negra" del sistema Boxly para mostrar los contenedores de software de alto nivel (Frontend, Backend, Bases de Datos) y cómo se comunican entre sí.

```mermaid
graph TD
    ACT["Cliente o Administrador"]
    FRONT["Web Frontend - SPA<br/>HTML/CSS/JS"]
    BACK["API Backend - ASP.NET Core / C#"]
    DB[("Base de Datos Relacional - PostgreSQL")]
    S3["Almacenamiento Cloud - AWS S3"]

    ACT -->|"HTTP/HTTPS"| FRONT
    FRONT -->|"API REST JSON"| BACK
    BACK -->|"SQL"| DB
    BACK -->|"Archivos"| S3

    %% Estilos
    style ACT fill:#fff,stroke:#333,color:#000
    style FRONT fill:#0082c3,color:#fff,stroke:#0082c3
    style BACK fill:#00875a,color:#fff,stroke:#00875a
    style DB fill:#d97706,color:#fff,stroke:#d97706
    style S3 fill:#d97706,color:#fff,stroke:#d97706
```

---

## C3: Nivel 3 - Diagrama de Componentes

Este nivel hace "zoom" dentro del contenedor de la **API Backend** para mostrar sus bloques de construcción (controladores y servicios) y sus responsabilidades respecto a los requisitos funcionales.

```mermaid
graph TD
    FE["Web Frontend"]

    subgraph API ["API Backend (ASP.NET Core / C#)"]
        AUTH["AuthController / UserService<br/>[Componente]<br/>Registro y Perfil<br/>(RF-01, RF-02, RF-03)"]
        CAT["CatalogController / CatalogService<br/>[Componente]<br/>Catálogo y Búsqueda<br/>(RF-05, RF-06, RF-07)"]
        SUB["SubscriptionController / BillingService<br/>[Componente]<br/>Pre-factura y Confirmación Manual<br/>(Usa Facade & Factory)"]
        LOG["LogisticsController / InventoryService<br/>[Componente]<br/>Inventario y Envíos con<br/>Strategy & Observer"]
        MET["MetricsController<br/>[Componente]<br/>Panel de Indicadores Básicos (RF-19)"]
    end

    DB[("Base de Datos")]

    FE -->|"HTTP REST"| AUTH
    FE -->|"HTTP REST"| CAT
    FE -->|"HTTP REST"| SUB
    FE -->|"HTTP REST"| LOG
    FE -->|"HTTP REST"| MET

    AUTH --> DB
    CAT --> DB
    SUB --> DB
    LOG --> DB

    %% Estilos
    style API fill:#1c2d42,color:#fff,stroke:#1c2d42
    style SUB fill:#00875a,color:#fff,stroke:#00875a
    style LOG fill:#00875a,color:#fff,stroke:#00875a
    style FE fill:#fff,stroke:#333
    style AUTH fill:#fff,stroke:#333,color:#000
    style CAT fill:#fff,stroke:#333,color:#000
    style MET fill:#fff,stroke:#333,color:#000
    style DB fill:#fff,stroke:#333,color:#000
```

---

## C4: Nivel 4 - Diagrama de Código (Clases)

Este nivel representa el modelo de datos interno y la estructura de clases principal del sistema. En este caso, se ilustra mediante un Diagrama de Clases UML enfocado en el dominio principal de la aplicación.

```mermaid
classDiagram
    class Persona {
        +int id
        +string nombre
        +string email
        +string contraseña
        +iniciarSesion() Boolean
        +actualizacionDatos() void
    }

    class Usuario {
        +string telefono
        +string direccion
        +string fechaRegistro
        +subscribirse(caja, plan) suscripcion
    }

    class Administrador {
        +string cargo
        +validarPagoManual() void
        +gestioncajas() void
    }

    class Caja {
        +int id
        +string nombre
        +string descripcion
        +decimal precio
    }

    class Producto {
        +int id
        +string nombre
        +decimal precio
    }

    class Inventario {
        +int cantidadDisponible
        +reponerstock(cantidad) void
        +hayDisponibilidad() boolean
    }

    class Suscripcion {
        +int id
        +Date fehainicio
        +Date fechafinal
        +Activar() void
    }

    class Plan {
        +int id
        +string nombre
        +decimal descuento
        +int tiempo
    }

    class Prefactura {
        +int id
        +decimal costoFinal
        +string Estado
        +confirmarPagoManual() void
    }

    class Envio {
        +int id
        +string descripcion
        +EstadoEnvio EstadoEnvio
    }

    %% Relaciones de Herencia
    Persona <|-- Usuario
    Persona <|-- Administrador

    %% Relaciones entre Clases
    Usuario "1" --> "*" Suscripcion : realiza
    Caja "1" --> "*" Producto : contiene
    Producto "1" --> "1" Inventario : tiene
    Suscripcion "1" --> "1" Plan : aplica
    Suscripcion "1" --> "1" Prefactura : genera
    Suscripcion "1" --> "1" Envio : incluye
```

## Reglas de negocio y requisitos visibles en el prototipo

- **RN-01:** Se requiere cuenta e inicio de sesión para adquirir un plan y gestionar la configuración.
- **RN-03:** La pre-factura incluye valor del plan + costo de envío + total.
- **RN-04:** La suscripción se activa tras registrar el pago.
- **RN-11:** Planes mensual, semestral y anual con descuento progresivo.


## Enlaces

- Repositorio: [https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly](https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly)
- Prototipo Figma: [https://www.figma.com/community/file/1676053533736794296](https://www.figma.com/community/file/1676053533736794296)

## Equipo

Andrés Felipe Orozco Paternina · Jose Manuel Pulgarin Rueda · Juan David Restrepo Alvarez · Jesús David Ávila Arrieta

Docente: Alexandra Guerrero Bocanegra — ITM, octubre de 2026.
