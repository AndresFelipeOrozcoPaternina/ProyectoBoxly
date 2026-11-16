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

# 1. Refinamiento y consolidación de los entregables 1 y 2

Esta sección sigue el primer punto de la guía **Entregable 3.docx**. Explica cómo el trabajo de E1 y E2 sirve de base para el sistema actual: qué se conservó, qué se llevó al código y qué debe ajustarse para que los documentos y el programa coincidan.

La comparación se hizo leyendo los entregables anteriores y el código actual. No se ejecutaron pruebas. Cuando un ajuste todavía no se ha realizado, se indica como pendiente.

## Tabla 1. Ajustes realizados frente a los entregables anteriores

| Elemento ajustado | Entregable de origen | Cómo estaba antes | Cómo quedó refinado | Motivo del ajuste |
| --- | --- | --- | --- | --- |
| Requisitos de compra y reglas de pago | E1: RF-09, RF-10, RF-11, RN-03 y RN-04. E2: prefacturación. | Se definió que el usuario elige un plan, revisa el total y confirma el pago. E2 planteó confirmación manual. | El código calcula el plan más el envío y simula un pago aprobado o rechazado. Solo activa la suscripción si el pago se aprueba. Queda pendiente ajustar la descripción de pago manual de E2. | Llevar las reglas de E1 a un proceso que el servidor pueda resolver y mostrar qué sucede si el pago falla. |
| Story mapping e historias de usuario del MVP | E1: actividades e historias del usuario. E2: historias priorizadas del MVP. | Se organizaron las funciones de explorar cajas, elegir un plan y contratar. E2 las presentó mediante páginas del prototipo. | Se conserva ese recorrido. La página de contratación envía la compra al servidor y muestra su respuesta. El catálogo sigue definido en el navegador. | Continuar el recorrido elegido en las entregas anteriores y precisar qué parte ya está conectada al servidor. |
| Prototipo funcional | E1: prototipo Figma. E2: prototipo HTML, CSS y JavaScript. | El diseño de pantallas se convirtió en un prototipo para recorrer la compra normal. | La contratación incorpora respuestas de compra aprobada y pago rechazado. Hay código para tratar otros errores de la solicitud. Su ejecución desde el navegador queda pendiente de verificar. | Ampliar el prototipo para explicar tanto una compra exitosa como las situaciones alternativas que pide E3. |
| Arquitectura C4 y organización del sistema | E2: niveles de contenedores y componentes. | Se propuso separar la interfaz, los servicios del servidor y una base de datos PostgreSQL. | El proyecto tiene carpetas de frontend y backend. El servidor separa controladores, servicios y acceso a datos, pero guarda las suscripciones en memoria. PostgreSQL queda como propuesta; falta actualizar los diagramas. | Mantener la separación diseñada en E2 y aclarar qué partes existen y cuáles faltan por construir. |
| Diagrama de clases y estados de la suscripción | E1: diagrama de clases. E2: nivel 4 de C4 y HU-3.4. | Se describieron las clases del sistema y funciones como contratar, pausar y cancelar. | El código define una clase de suscripción y estados de pago pendiente, activa, pago rechazado, pausada y cancelada. Implementa aprobación, rechazo y cancelación; la pausa está pendiente. Esta información servirá para el punto 2. | Usar las clases anteriores como base de la máquina de estados y dibujar cambios que correspondan al comportamiento del programa. |
| Patrones de diseño | E2: selección de cinco patrones GoF y anexo de análisis. | Se eligieron Factory Method, Builder, Strategy, Observer y Facade para organizar las responsabilidades del sistema. | Existen clases para los cinco patrones. La creación de planes, el cálculo del cobro y los avisos de cambios tienen código. La compra todavía no llama a la asignación de productos por preferencias; los avisos de correo son mensajes de registro. | Conservar las decisiones de E2 y precisar hasta dónde se aplicaron, sin presentar funciones incompletas como terminadas. |
| Principios SOLID | E2: análisis y anexo SOLID. | Se propuso separar responsabilidades y usar interfaces para reducir la dependencia entre clases. | El controlador recibe solicitudes, el servicio coordina la compra, la fachada calcula el cobro y el repositorio guarda datos. El servicio recibe estas dependencias mediante interfaces. Falta ajustar en los documentos los nombres que no coinciden con el código. | Mostrar con clases concretas cómo las ideas de E2 se reflejan en la organización del programa. |
| Diagramas de actividades previos | E2: catálogo, detalle y contratación. | Se dibujó el recorrido principal de las historias del MVP. | Se conserva ese recorrido como referencia. El código de contratación añade caminos de caja inexistente, falta de existencias y pago rechazado. Actualizar los diagramas y crear los de E3 sigue pendiente. | Usar los diagramas anteriores como punto de partida para explicar las decisiones y errores del proceso actual. |
| Reglas que requieren más trabajo | E1: RN-01, RN-02, RN-07, RN-08 y RN-09. E2: almacenamiento e inventario. | Se pidió acceso por usuario, una suscripción activa por periodo, descuento de inventario al preparar el envío y seguimiento de la entrega. | La revisión conserva estas reglas como pendientes: el servidor no comprueba la identidad del usuario ni las suscripciones repetidas; descuenta la caja al aprobar el pago y no implementa el recorrido de envío. También falta guardar los datos de forma permanente. | Mantener visibles los compromisos de E1 y E2 y evitar que una función pendiente se confunda con un ajuste ya terminado. |

## Qué comparamos y por qué

Comparamos los **productos de E1 y E2** con su uso en el **MVP actual**, como pide el primer punto del Word. La tabla explica la continuidad del proyecto: requisitos → diseño → código.

Por ejemplo, E1 definió que una suscripción solo se activa con el pago confirmado. E2 propuso cómo resolver el cobro. El código actual simula el pago y decide si activa o rechaza la suscripción. Esta comparación tiene sentido porque muestra cómo una regla de la primera entrega llega a convertirse en una acción del programa.

Los ajustes de documentación realizados aquí aclaran esa relación. Los cambios de código y de diagramas señalados como pendientes todavía deben hacerse; esta tabla no los da por terminados.

## Tabla 2. Evidencias para verificar la comparación

Las rutas parten de esta carpeta. Estos enlaces permiten comprobar las afirmaciones de la tabla anterior.

| Referencia | Qué se comparó | Evidencia anterior | Evidencia actual y qué revisar |
| --- | --- | --- | --- |
| Recorrido de compra | Requisitos y HU frente a la integración web | [E1: requisitos](../entregable1/Entregable_1.md); [E2: sección 1.1](../entregable2/Arquitectura%20C4.md) | [script.js](../../front/js/script.js): `CATALOGO`, petición `POST` a suscripciones y respuestas del servidor. |
| Pago e inventario | Reglas de cobro, inventario y unicidad frente a la contratación | [E1: reglas de negocio](../entregable1/Entregable_1.md); [E2: decisiones de pago](../entregable2/Arquitectura%20C4.md) | [SuscripcionService.cs](../../backend/Boxly.Api/Services/SuscripcionService.cs): `CrearSuscripcionAsync`; [FacturacionFacade.cs](../../backend/Boxly.Api/Patterns/Facade/FacturacionFacade.cs): liquidación y pago simulado. |
| Estados | Estados de interfaz, suscripción y envío | [E1: RN-08](../entregable1/Entregable_1.md); [E2: HU-3.4](../entregable2/Arquitectura%20C4.md) | [EstadoSuscripcion.cs](../../backend/Boxly.Api/Models/Enums/EstadoSuscripcion.cs); [SuscripcionService.cs](../../backend/Boxly.Api/Services/SuscripcionService.cs): creación y cancelación. |
| Arquitectura | Contenedores y componentes proyectados frente a clases registradas | [E2: C4 niveles 2 a 4](../entregable2/Arquitectura%20C4.md) | [Program.cs](../../backend/Boxly.Api/Program.cs): DI; [SuscripcionRepository.cs](../../backend/Boxly.Api/Repositories/SuscripcionRepository.cs): diccionario en memoria. |
| Patrones y SOLID | Justificación de patrones y SOLID frente a su uso | [Anexo GoF](../entregable2/Anexo_Plantilla_GoF.md); [Anexo SOLID](../entregable2/Anexo_Plantilla_SOLID.md) | [Strategy](../../backend/Boxly.Api/Patterns/Strategy/AsignacionStrategy.cs); [Observer](../../backend/Boxly.Api/Patterns/Observer/SuscripcionObserver.cs); [SuscripcionService.cs](../../backend/Boxly.Api/Services/SuscripcionService.cs); [Program.cs](../../backend/Boxly.Api/Program.cs). |
| Acceso por usuario | Restricciones de acceso frente a endpoints y configuración | [E1: RN-01, RN-09 y requisitos de seguridad](../entregable1/Entregable_1.md) | [SuscripcionesController.cs](../../backend/Boxly.Api/Controllers/SuscripcionesController.cs): listado sin filtro de identidad; [Program.cs](../../backend/Boxly.Api/Program.cs): configuración de servicios y middleware. |
| Pruebas existentes | Demostración del camino principal frente a casos alternativos | [Guía E2: sección 4](../entregable2/Entregable_2.md) | [TestSuiteRunner.cs](../../backend/Boxly.Api/Services/TestSuiteRunner.cs): casos y aserciones existentes. Esta revisión no ejecutó la suite. |



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

### 7.1 Enlaces Principales
* **Repositorio Git Oficial:** [https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly](https://github.com/AndresFelipeOrozcoPaternina/ProyectoBoxly)
* **Rama de Trabajo de Backend y MVP:** `rama-jose`
* **Prototipo Figma:** [https://www.figma.com/community/file/1676053533736794296](https://www.figma.com/community/file/1676053533736794296)

### 7.2 Evidencia de la Suite de Pruebas Automatizadas (10/10 Casos Aprobados)
Salida generada al ejecutar el comando `dotnet run --project backend/Boxly.Api -- --verify-suite`:

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
  [PASS] Happy Path: Contratación y pago aprobado (RN-04: Estado pasa a Activa) -> Suscripción ID=7E74F492, Estado=Activa
  [PASS] Flujo Alternativo 1: Caja no existente rechazada controladamente (404) -> La caja temática solicitada ('caja-fantasma-no-existe') no fue encontrada en el sistema.
  [PASS] Flujo Alternativo 2: Pago declinado por entidad bancaria (RN-04: No activa, queda en PagoRechazado) -> Estado=PagoRechazado, Motivo='La entidad bancaria rechazó la transacción por fondos insuficientes o tarjeta no autorizada.'
  [PASS] Flujo Alternativo 3: Cancelación de suscripción activa por el usuario -> Estado actualizado a: Cancelada
  [PASS] Flujo Alternativo 4: Control de idempotencia ante cancelación duplicada -> La suscripción ya se encuentra en estado cancelado.

----------------------------------------------------------------------
RESULTADO FINAL: 10 Pruebas Exitosas | 0 Pruebas Fallidas
======================================================================
``` 

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

