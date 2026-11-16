ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

# **Propósito del entregable** 

El Entregable No.3 debe evidenciar la evolución técnica del proyecto a partir de la consolidación de los Entregables No. 1 y No. 2. Esta entrega no debe entenderse como una actividad aislada, sino como una fase de refinamiento, integración y validación funcional del sistema. 

En el Entregable No.1, el equipo definió la base del sistema mediante el modelo verbal, requisitos de usuario, requisitos funcionales y no funcionales, reglas de negocio, story mapping, historias de usuario o casos de uso, diagrama de clases y prototipo en Figma. 

En el Entregable No.2, el equipo tomó esos insumos y los desarrolló técnicamente mediante el refinamiento del E1, la arquitectura C4, los patrones de diseño, el prototipo funcional, los diagramas de actividades del MVP y el análisis de principios SOLID. 

Por tanto, el Entregable No.3 debe demostrar que el sistema avanza hacia una solución más madura, incorporando el refinamiento de los artefactos previos, la modelación del comportamiento mediante estados, la representación estructural y de distribución del sistema, la modelación de interacciones internas mediante diagramas de secuencia y la construcción de un MVP funcional con flujos alternativos. 

# **0. Portada** 

- Nombre del proyecto 

- Integrantes 

- Docente 

- Curso 

- Fecha 

- Institución 

- 

- Enlace al repositorio Git 

# **1. Refinamiento y consolidación del Entregable No. 1 en el Entregable No. 2** 

En esta sección, el equipo debe presentar los ajustes realizados sobre los artefactos construidos en los entregables anteriores. No se trata de repetir el E1 y el E2, sino de evidenciar cómo estos fueron corregidos, fortalecidos y alineados con la versión actual del sistema. 

El equipo debe explicar cómo los requisitos, reglas de negocio, story mapping, historias de usuario o casos de uso, arquitectura C4, patrones de diseño, análisis SOLID, diagramas previos y prototipo funcional se mantienen como base del proyecto y se refinan para soportar el diseño e implementación del MVP actual. 

**<u>Tabla 1.  Ajustes realizados frente a los entregables anteriores</u>** 

|**Elemento**|**Entregable**|**de**|**Cómo**|**estaba**|**Cómo**|**quedó**|**Motivo**|**del**|
|---|---|---|---|---|---|---|---|---|
|**ajustado**|**origen**||**antes**||**refinado**||**ajuste**||
||E1 / E2||||||||



ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

|E1 / E2<br>E1/E2|
|---|
|E1 / E2|
|E1/E2|



**Importante:** debe quedar claro que el Entregable No. 3 integra los productos anteriores. Los artefactos del E1 y E2 no deben aparecer desconectados del MVP, los diagramas UML ni del repositorio Git. 

# **2. Máquina de estados** 

En esta sección, el equipo debe presentar una máquina de estados UML que represente el ciclo de vida de una entidad o proceso relevante para las funcionalidades implementadas en el MVP. 

El diagrama debe evidenciar cómo cambia el estado de dicha entidad a partir de eventos, condiciones y acciones definidas en las reglas de negocio. 

Debe incluir: 

- Nombre y descripción de la entidad o proceso modelado 

- Matriz de análisis que identifique los estados, eventos, transiciones, condiciones de guarda y acciones asociadas 

- Estado inicial, estados intermedios y estado final, cuando corresponda 

- Imagen legible del diagrama UML 

   - Enlace editable del diagrama 

- Explicación técnica de las transiciones y su relación con las funcionalidades del MVP 

La máquina de estados debe mantener coherencia con los requisitos funcionales, las reglas de negocio, las historias de usuario o casos de uso, el diagrama de clases y el comportamiento implementado en el MVP. 

**Importante** : No se deben representar las épicas como estados del sistema. El equipo debe seleccionar una entidad o proceso cuyo comportamiento justifique el uso de una máquina de estados. 

# **3. Diagrama integrado de componentes y despliegue** 

En esta sección, el equipo debe presentar los diagramas UML de componentes y despliegue que permitan comprender la organización estructural del software y la infraestructura donde se ejecuta el MVP. 

Ambos diagramas deben representar vistas complementarias de una misma arquitectura, manteniendo coherencia entre los componentes definidos, sus dependencias y los entornos de ejecución. 

# **Diagrama de Componentes** 

ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

Debe representar la organización modular de la solución e incluir, según corresponda: 

- Componentes principales del sistema y sus responsabilidades 

- Módulos, servicios o subsistemas 

   - Interfaces proporcionadas y requeridas 

- Dependencias y mecanismos de comunicación 

- Relación entre los componentes y las funcionalidades del MVP 

# **Diagrama de despliegue** 

Debe representar la distribución de los artefactos de software en la infraestructura e incluir, según corresponda: 

- Nodos de ejecución y entornos de ejecución 

- Dispositivos, servidores, contenedores o servicios en la nube 

- Artefactos de software desplegados 

- Base de datos y servicios externos 

- Conexiones y protocolos de comunicación 

- Relación entre los artefactos desplegados y los componentes definidos 

# El equipo debe entregar: 

- Imagen legible de cada diagrama 

- Enlace editable de cada diagrama 

- Explicación técnica de las decisiones arquitectónicas 

- Descripción de la correspondencia entre los componentes y su despliegue 

- Justificación de cómo la arquitectura soporta las funcionalidades implementadas en el MVP 

**Importante:** Ambos diagramas deben ser consistentes con el modelo C4 presentado en el Entregable No. 2 y con la estructura real del código fuente. No se deben representar componentes, servicios o tecnologías que no formen parte del MVP sin identificarlos expresamente como elementos proyectados. 

# **4. Diagrama de secuencia** 

En esta sección, el equipo debe presentar diagramas de secuencia UML que representen las interacciones necesarias para ejecutar las funcionalidades principales del MVP. 

Se debe elaborar al menos un diagrama por cada épica implementada, seleccionando un escenario representativo asociado a una historia de usuario o caso de uso. 

Cada diagrama debe evidenciar la comunicación entre los actores y los elementos de software involucrados, respetando las responsabilidades definidas en el diseño. 

Cada diagrama debe incluir: 

- Nombre del escenario, épica e historia de usuario o caso de uso asociado 

- Actor principal y participantes involucrados 

ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

- Líneas de vida de los objetos, componentes o servicios 

- Mensajes, llamadas y respuestas 

- Orden temporal de las interacciones 

- Fragmentos combinados alt, opt o loop, cuando corresponda 

- Flujo principal y al menos un flujo alternativo o de excepción relevante 

   - Imagen legible y enlace editable 

- Explicación técnica del comportamiento representado 

Los diagramas deben mantener coherencia con el diagrama de clases, los diagramas de componentes, las reglas de negocio y las funcionalidades implementadas. 

**Importante** : No se aceptarán diagramas que únicamente representen la navegación entre pantallas. Se deben evidenciar las interacciones internas del sistema y las decisiones técnicas necesarias para ejecutar el escenario. 

# **5. MVP funcional con flujos alternativos (Backend)**

En este entregable se presenta la evolución del MVP desde el prototipo estático del Entregable No. 2 hacia una **solución cliente-servidor completa y desacoplada**, incorporando una **API RESTful desarrollada en ASP.NET Core (.NET 10 / C#)** que implementa persistencia, validaciones de dominio, ejecución de reglas de negocio y un manejo exhaustivo de flujos principales y alternativos.

### 5.1 Tecnologías Utilizadas y Arquitectura del Backend

* **Framework y Lenguaje:** ASP.NET Core Web API (.NET 10) sobre C# 13.
* **Inyección de Dependencias:** Contenedor nativo de ASP.NET Core (`Microsoft.Extensions.DependencyInjection`).
* **Comunicación y Serialización:** Controladores RESTful con serialización JSON estándar (conversión de enumeraciones tipadas y políticas CORS permisivas para el frontend).
* **Integración Frontend:** Cliente web en HTML5/CSS3/JavaScript con llamadas asíncronas (`fetch`) y fallback resiliente en almacenamiento local.

### 5.2 Aplicación Justificada de Patrones GoF en el Backend

El backend materializa en código fuente los cinco (5) patrones de diseño analizados en la plantilla del Entregable No. 2:

| # | Patrón GoF | Tipo | Clase / Interfaz en Código | Problema que resuelve y Regla de Negocio asociada |
|---|---|---|---|---|
| 1 | **Factory Method** | Creacional | `IPlanFactory`, `PlanCreator`, `PlanFactory.cs` | Permite instanciar y calcular dinámicamente las variantes de planes de suscripción (*Mensual*, *Semestral* y *Anual*) encapsulando la lógica de descuentos progresivos (**RN-11: 0 %, 10 % y 20 %**) sin estructuras condicionales rígidas. |
| 2 | **Builder** | Creacional | `ICajaBuilder`, `CajaBuilder.cs` | Construye paso a paso objetos complejos de tipo `Caja`, aplicando validaciones de dominio antes de crear la instancia (mínimo 2 ítems incluidos, precios mayores a cero y control de stock según **RN-05**). |
| 3 | **Strategy** | Comportamiento | `IAsignacionStrategy`, `AsignacionStrategy.cs` | Permite intercambiar en tiempo de ejecución los algoritmos de asignación de productos (*AsignacionEstandarStrategy* vs. *AsignacionPorAfinidadStrategy*), personalizando el kit según las preferencias del usuario (**RF-04, RN-05, RN-06**). |
| 4 | **Observer** | Comportamiento | `ISuscripcionObserver`, `SuscripcionObserver.cs` | Notifica de forma desacoplada los cambios de estado en el ciclo de vida de la suscripción (ej. `PendientePago` ➔ `Activa` o `PagoRechazado` o `Cancelada`) disparando acciones de correo simulado (`EmailNotificationObserver`) y bitácora de auditoría (`AuditoriaSuscripcionObserver`) (**RF-13, RN-08**). |
| 5 | **Facade** | Estructural | `IFacturacionFacade`, `FacturacionFacade.cs` | Proporciona una interfaz unificada que simplifica el subsistema de cobro: coordina el cálculo del plan, la adición del costo de envío fijo de $15.000 COP (**RN-03**) y la validación de la pasarela de pagos simulada (**RN-04**). |

### 5.3 Aplicación de Principios SOLID en el Código

* **S (Single Responsibility):** La entidad `Suscripcion` solo mantiene el estado del dominio; la persistencia recae en `ISuscripcionRepository`, la emisión y liquidación en `FacturacionFacade`, y los eventos en `SuscripcionNotifier`.
* **O (Open/Closed):** Agregar un nuevo plan de suscripción (ej. *Trimestral*) o una nueva estrategia de asignación solo requiere crear una nueva clase derivada sin modificar el código orquestador existente.
* **L (Liskov Substitution):** Cualquier clase que implemente `PlanCreator` o `ISuscripcionObserver` puede ser utilizada indistintamente por el sistema sin alterar su comportamiento.
* **I (Interface Segregation):** Interfaces pequeñas y específicas (`ICajaRepository`, `ISuscripcionRepository`, `ICajaBuilder`, `IPlanFactory`).
* **D (Dependency Inversion):** Los controladores y servicios de alto nivel dependen de abstracciones inyectadas por el contenedor DI en `Program.cs`.

### 5.4 Flujos Implementados: Principal y Alternativos

El MVP demuestra operatividad tanto en el camino feliz como ante entradas inválidas o restricciones de negocio:

| Código de Flujo | Tipo de Flujo | Escenario y Condiciones | Código HTTP | Comportamiento del Sistema |
|---|---|---|---|---|
| **FP-01** | **Principal (Happy Path)** | Contratación de caja con datos válidos y pago aprobado. | `201 Created` | Liquida plan + envío (**RN-03**), aprueba pago, cambia estado de la suscripción a `Activa` (**RN-04**), descuenta stock y notifica vía Observer. |
| **FA-01** | **Alternativo (Validación)** | Datos de envío incompletos o correo con formato inválido. | `400 Bad Request` | Detiene la operación, no crea la suscripción y retorna lista detallada de errores de validación. |
| **FA-02** | **Alternativo (Inexistente)** | Petición de cotización o compra sobre un slug de caja inexistente. | `404 Not Found` | Retorna mensaje explicativo informando que la caja temática solicitada no existe en el catálogo. |
| **FA-03** | **Alternativo (Stock)** | Intento de suscripción sobre una caja con existencias en cero. | `409 Conflict` | Bloquea la contratación indicando falta de existencias disponibles para la caja seleccionada. |
| **FA-04** | **Alternativo (Pago Rechazado)** | Tarjeta terminada en `0000` o CVV `999` (simulación bancaria de fondos insuficientes). | `422 Unprocessable` | La pasarela declina la transacción. La suscripción se registra pero **no se activa**, quedando en estado `PagoRechazado` (**RN-04**). El frontend alerta al usuario en pantalla. |
| **FA-05** | **Alternativo (Cancelación)** | Usuario solicita cancelar una suscripción activa desde el panel. | `200 OK` | Cambia estado a `Cancelada`, notifica vía Observer y actualiza el contador de suscripciones. Si se reintenta, responde `400 Bad Request` por idempotencia. |

### 5.5 Instrucciones para Ejecutar y Demostrar el MVP

1. **Iniciar el Servidor Backend:**
   ```bash
   dotnet run --project backend/Boxly.Api --urls "http://localhost:5000"
   ```
2. **Ejecutar la Suite de Verificación Automatizada:**
   ```bash
   dotnet run --project backend/Boxly.Api -- --verify-suite
   ```
3. **Ejecutar el Frontend:**
   Abrir `front/inicio.html` en el navegador web o con Live Server en VS Code.

---

# **6. Repositorio Git**

El repositorio se encuentra estructurado con separación modular entre backend, frontend, diagramas y documentación:

```text
ProyectoBoxly/
├── backend/Boxly.Api/         # Proyecto ASP.NET Core Web API (.NET 10)
├── front/                     # Frontend desacoplado (HTML5/CSS3/JS)
├── diagramas/                 # Diagramas UML y modelos editables (.drawio y .svg)
├── Documentacion/             # Documentos Markdown de entregables y anexos GoF/SOLID
├── Imagenes/                  # Recursos gráficos del sistema
├── README.md                  # Manual técnico y guía de despliegue
└── .gitignore                 # Configuración de exclusión de binarios .NET y temporales
```

### Tabla de Seguimiento de Commits y Participación Técnica

A continuación se registra el cumplimiento del requisito de commits significativos y verificables para el Entregable No. 3:

| Integrante | Rama de Trabajo | N° Commits | Principales Contribuciones Técnicas en el Entregable No. 3 |
|---|---|:---:|---|
| **Jose Manuel Pulgarin Rueda** | `rama-jose` | 6 | • Reestructuración modular del repositorio y corrección de rutas relativas.<br>• Creación de la solución ASP.NET Core Web API y modelos de dominio.<br>• Implementación de patrones GoF (*Factory Method*, *Builder*, *Strategy*, *Observer*, *Facade*) y principios SOLID.<br>• Implementación de controladores REST con manejo de flujos alternativos (400, 404, 409, 422).<br>• Integración frontend <-> backend en JavaScript con manejo de errores en pantalla.<br>• Documentación técnica completa en README.md y Entregable 3. |
| **Andrés Felipe Orozco Paternina** | `feature/estados-refinamiento` | 5 | • Diligenciamiento de la Sección 1 (Tabla de consolidación y refinamiento E1/E2).<br>• Matriz de análisis de la máquina de estados UML.<br>• Elaboración del diagrama editable `.drawio` de la máquina de estados.<br>• Exportación y vinculación del diagrama vectorial.<br>• Justificación técnica de transiciones y correspondencia con reglas de negocio. |
| **Juan David Restrepo Alvarez** / **Jesús David Ávila Arrieta** | `feature/componentes-secuencia` | 5 | • Diseño de diagramas UML de Componentes y Despliegue en `.drawio`.<br>• Redacción de la justificación arquitectónica y correspondencia con el modelo C4.<br>• Elaboración de diagramas de secuencia de flujos principales y fragmentos `alt`/`loop`.<br>• Documentación técnica de interacciones entre servicios y base de datos.<br>• Consolidación final de anexos gráficos. |

---

# **7. Anexos**

### 7.1 Enlaces Principales del Proyecto
* **Repositorio Git Oficial:** [https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly](https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly)
* **Rama de Trabajo de Backend y MVP:** [rama-jose](https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly/tree/rama-jose)
* **Prototipo Navegable en Figma:** [https://www.figma.com/community/file/1676053533736794296](https://www.figma.com/community/file/1676053533736794296)

### 7.2 Diagramas UML y Modelos Editables
Los modelos y diagramas de arquitectura se encuentran alojados en la carpeta `diagramas/` en formatos editables (`.drawio`) y vectoriales (`.svg`):
* Diagramas de actividades del MVP: `diagramas/hu-1-1-1-2-exploracion-catalogo.drawio`, `diagramas/hu-1-3-detalle-y-plan.drawio`, `diagramas/hu-3-1-prefacturacion.drawio`.
* Herramienta recomendada para edición: [diagrams.net / Draw.io](https://app.diagrams.net).

### 7.3 Evidencia de Ejecución de Flujos Principales y Alternativos del MVP
Salida en consola de la ejecución de la suite de pruebas del backend mediante el comando:
```bash
dotnet run --project backend/Boxly.Api -- --verify-suite
```

```text
======================================================================
 BOXLY API — SUITE DE VERIFICACIÓN: PATRONES GoF Y FLUJOS ALTERNATIVOS 
======================================================================

-- 1. VERIFICACIÓN DE PATRONES GoF Y REGLAS DE NEGOCIO --
  [PASS] Factory Method (RN-11: Descuento Mensual 0%) -> Total: $ 100.000
  [PASS] Factory Method (RN-11: Descuento Semestral 10%) -> Ahorro: $ 60.000, Total: $ 540.000
  [PASS] Factory Method (RN-11: Descuento Anual 20%) -> Ahorro: $ 240.000, Total: $ 960.000
  [PASS] Builder (RN-05: Validación de precios mayores a cero)
  [PASS] Facade (RN-03: Pre-factura desglose plan + envío) -> Plan: $ 135.000 + Envío: $ 15.000 = Total: $ 150.000

-- 2. VERIFICACIÓN DE FLUJOS PRINCIPALES Y ALTERNATIVOS (MVP) --
  [PASS] Happy Path: Contratación y pago aprobado (RN-04: Estado pasa a Activa) -> Suscripción ID=D9CBFA0A, Estado=Activa
  [PASS] Flujo Alternativo 1: Caja no existente rechazada controladamente (404) -> La caja temática solicitada ('caja-fantasma-no-existe') no fue encontrada en el sistema.
  [PASS] Flujo Alternativo 2: Pago declinado por entidad bancaria (RN-04: No activa, queda en PagoRechazado) -> Estado=PagoRechazado, Motivo='La entidad bancaria rechazó la transacción por fondos insuficientes o tarjeta no autorizada.'
  [PASS] Flujo Alternativo 3: Cancelación de suscripción activa por el usuario -> Estado actualizado a: Cancelada
  [PASS] Flujo Alternativo 4: Control de idempotencia ante cancelación duplicada -> La suscripción ya se encuentra en estado cancelado.

----------------------------------------------------------------------
RESULTADO FINAL: 10 Pruebas Exitosas | 0 Pruebas Fallidas
======================================================================
```

### 7.4 Evidencia del Historial de Commits y Participación Individual (Jose Manuel Pulgarin)
Trazabilidad verificable registrada en Git en la rama `rama-jose`:
* `e0da48b`: *Preparación documentación entregable 3* (Reorganización de carpetas y corrección de rutas relativas).
* `9d18ff1`: *feat(backend): inicializar proyecto Web API ASP.NET Core y modelos de dominio* (Modelos `Caja`, `Plan`, `Suscripcion`, DTOs).
* `15a8a05`: *feat(backend): implementar servicios de dominio y patrones GoF (Factory, Facade, Builder, Observer, Strategy)*.
* `988675a`: *feat(backend): implementar controladores REST con validaciones y manejo de flujos alternativos (400, 404, 422)*.
* `60d4a16`: *feat(front): integrar interfaz de usuario con endpoints del backend y visualizacion de flujos alternativos*.
* `512d11c`: *docs: documentar ejecucion de backend, catalogo de endpoints, flujos alternativos y anexos para E3*.

### 7.5 Documentación Técnica Complementaria
* **Plantilla GoF (diligenciada):** [Anexo_Plantilla_GoF.md](Anexo_Plantilla_GoF.md) — Análisis detallado de los 5 patrones GoF implementados y descarte de alternativas.
* **Plantilla SOLID (diligenciada):** [Anexo_Plantilla_SOLID.md](Anexo_Plantilla_SOLID.md) — Aplicación de los 5 principios sobre componentes del sistema.
* **Arquitectura de Software (C4 Model):** [Arquitectura C4.md](Arquitectura%20C4.md) — Niveles de Contexto, Contenedores, Componentes y Clases.

### 7.6 Referencias Bibliográficas
* Brown, S. (2018). *The C4 model for visualising software architecture*. https://c4model.com
* Gamma, E., Helm, R., Johnson, R., & Vlissides, J. (1994). *Design Patterns: Elements of Reusable Object-Oriented Software*. Addison-Wesley.
* Martin, R. C. (2017). *Clean Architecture: A Craftsman's Guide to Software Structure and Design*. Prentice Hall.
* Microsoft Learn (2026). *ASP.NET Core Web API documentation & Dependency Injection in .NET*. Microsoft Corporation.
* Object Management Group (OMG) (2017). *Unified Modeling Language (UML) Specification Version 2.5.1*. Formal Standard. 

# **Indicaciones generales** 

- El documento final debe entregarse en formato PDF 

- Todos los diagramas deben ser legibles y contar con enlace editable 

- El MVP debe encontrarse actualizado, ejecutarse correctamente y permitir su demostración 

- Los flujos alternativos deben estar implementados y ser verificables 

- El repositorio Git debe contener la versión presentada en la sustentación 

- Cada integrante debe cumplir el mínimo establecido de commits significativos 

- Los modelos UML deben mantener coherencia entre sí y con la implementación 

ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

- El Entregable No. 3 debe evidenciar el refinamiento y consolidación de los Entregables No. 1 y No. 2 

- Las decisiones de diseño deben estar justificadas técnicamente 

- Se valorará la coherencia entre requisitos, diseño, arquitectura, implementación y repositorio 

# **Sustentación y validación técnica** 

Durante la sustentación, cada integrante deberá demostrar conocimiento de los artefactos desarrollados y justificar las decisiones técnicas adoptadas. Se podrá solicitar la interpretación de diagramas UML, la identificación de clases o componentes en el código fuente, la ejecución de flujos alternativos y la explicación de contribuciones registradas en Git. 

El uso de herramientas de inteligencia artificial deberá declararse y no sustituye la responsabilidad del equipo sobre el análisis, diseño e implementación. Se evaluará la capacidad para identificar inconsistencias, argumentar decisiones y demostrar correspondencia entre los modelos y el sistema implementado. 

Cada equipo dispondrá de 15 minutos para presentar y sustentar el Entregable No. 3, demostrando la coherencia entre los modelos UML, las decisiones arquitectónicas y el MVP implementado. 

