# ProyectoBoxly

Prototipo funcional de **Boxly**, plataforma SaaS de gestión y contratación de cajas de suscripción temáticas (Gaming, Fitness, Cuidado Personal, Tecnología). Desarrollado para el curso de **Diseño de Sistemas de Información** del Instituto Tecnológico de Medellín (ITM) — Entregable No. 2.

## Cómo ejecutar el prototipo

No requiere instalación ni compilación. Abre `front/inicio.html` en cualquier navegador moderno (o ejecuta el proyecto mediante **Live Server** en VS Code abriendo la carpeta `front/`) y navega el Happy Path:

1. **`front/inicio.html`** — Catálogo general con filtros por categoría (HU-1.1, HU-1.2).
2. **`front/detalle.html`** — Detalle de la caja y selección de plan Mensual / Semestral (−10 %) / Anual (−20 %) (HU-1.3).
3. **`front/facturacion.html`** — Dirección de envío, método de pago y pre-factura con desglose plan + envío = total (HU-3.1, RN-03).
4. **`front/cajas.html`** — Panel «Mis cajas»: la suscripción confirmada aparece como **Activa**.
5. **`front/configuracion.html`** — Sección de configuración de cuenta: gestión de datos personales (RF-03), selección de intereses y preferencias (RF-04), visualización de métricas de usuario y función para **cerrar sesión** con redirección a `login.html`.

Páginas complementarias: `front/registro.html` (HU-2.1), `front/login.html` (HU-2.2), `front/bonos.html` (programa de recompensas).

## Estructura del repositorio

| Archivo / carpeta | Descripción |
| --- | --- |
| `front/` | Carpeta del prototipo web frontend |
| ├── `inicio.html`, `detalle.html`, `facturacion.html`, `cajas.html` | Flujo principal del MVP |
| ├── `configuracion.html` | Configuración de perfil, preferencias, estadísticas y cierre de sesión (RF-03, RF-04) |
| ├── `registro.html`, `login.html` | Autenticación y acceso al sistema (RN-01) |
| ├── `bonos.html` | Programa de bonos y recompensas |
| ├── `css/estilos.css` | Estilos compartidos y paleta corporativa |
| └── `js/script.js` | Lógica de catálogo, cálculo de planes y persistencia en `localStorage` |
| `Imagenes/` | Imágenes locales (`bonos_1.jpeg`, `bonos_2.jpeg`) |
| `diagramas/` | Diagramas de actividades del MVP (`.drawio` editables + `.svg`) |
| `Documentacion/` | Documentos del curso (`Entregable_1.md`, `Entregable_2.md`, `Entregable_3.md`, `Arquitectura C4.md`, anexos GoF y SOLID) |


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
