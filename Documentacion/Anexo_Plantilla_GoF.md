# Anexo A — Plantilla de Análisis y Selección de Patrones GoF (diligenciada)

**Proyecto:** Boxly — Entregable No. 2
**Curso:** Diseño de Sistemas de Información — ITM
**Material de referencia:** `Infografía de GoF.jpeg` (catálogo de los 23 patrones GoF con tipo, definición y diagrama UML de cada uno, incluido en el repositorio como anexo visual).
**Patrones seleccionados:** 5 de 23 · sin repetición · dentro del alcance del MVP.

---

## A.1 Criterios de selección

1. Cada patrón resuelve una **necesidad concreta** del MVP, trazable a RF / RN / HU del Entregable 1.
2. **Sin repetición:** un único patrón por problema de diseño; ningún patrón se asigna a dos problemas.
3. **Sin sobreingeniería:** implementación viable en tiempo y complejidad de un proyecto académico.
4. **Categorías cubiertas:** 2 Creacionales + 1 Estructural + 2 de Comportamiento (sin desbalance).

## A.2 Matriz resumen de selección

| # | Patrón | Tipo (GoF) | Problema de diseño que resuelve | Trazabilidad (E1) |
| --- | --- | --- | --- | --- |
| 1 | Factory Method | Creacional | Crear variantes de planes sin `if/switch` rígidos | RF-08, RF-17, RN-11 |
| 2 | Builder | Creacional | Construir `Caja` compleja paso a paso con validaciones | RF-04, RF-18, RN-05 |
| 3 | Strategy | Comportamiento | Intercambiar algoritmos de asignación de productos | RF-04, RN-05, RN-06 |
| 4 | Observer | Comportamiento | Notificar cambios de estado del envío sin acoplar | RF-13, RN-08 |
| 5 | Facade | Estructural | Unificar el subsistema de pre-facturación | RF-10, RF-11, RN-03 |

---

## A.3 Análisis por patrón

Formato: campos de la infografía de referencia (**Tipo**, **Qué es**, **Roles UML**) + campos exigidos por el rubro del Entregable 2.

---

### Patrón 1: Factory Method

| Campo | Diligenciamiento |
| --- | --- |
| **Tipo (GoF)** | Creacional |
| **Qué es (según la infografía)** | Define una interfaz para crear un objeto, pero deja a las subclases decidir qué clase instanciar. El código cliente trabaja con la abstracción, no con las clases concretas. |
| **Necesidad en BOXLY (MVP)** | El negocio maneja tres planes (Mensual, Semestral, Anual) con descuentos, vigencias y reglas de renovación distintas (RN-11). Instanciar planes directamente en el controlador obligaría a `if/switch` rígidos que violan Open/Closed. |
| **Alternativas consideradas** | *Abstract Factory:* descartado por sobreingeniería (no hay familias de objetos interrelacionados). *Instanciación directa (`new PlanMensual()`):* descartada por violar Open/Closed. *Prototype:* descartado (no se clonan configuraciones existentes). |
| **Aplicación concreta** | `SuscripcionFactory` (creadora abstracta) con `crearSuscripcion(tipoPlan)`; subclases concretas que configuran descuento, vigencia y condiciones del plan. |
| **Evidencia en el prototipo** | `detalle.html` implementa la selección Mensual / Semestral (−10 %) / Anual (−20 %) y calcula el valor según el plan elegido. |
| **Validación de no solapamiento** | Responsabilidad exclusiva: **origen de los objetos de Plan/Suscripción**. No construye cajas paso a paso (Builder) ni notifica eventos (Observer). |
| **Roles UML → clases BOXLY** | *Creator* → `SuscripcionFactory`; *ConcreteCreator* → `PlanMensualFactory`, `PlanSemestralFactory`, `PlanAnualFactory`; *Product* → `ISuscripcion`. |

---

### Patrón 2: Builder

| Campo | Diligenciamiento |
| --- | --- |
| **Tipo (GoF)** | Creacional |
| **Qué es (según la infografía)** | Separa la construcción de un objeto complejo de su representación, permitiendo el mismo proceso de construcción con distintas representaciones (construcción paso a paso). |
| **Necesidad en BOXLY (MVP)** | Una `Caja` no es estática: requiere validar inventario (RN-06), combinar categorías según preferencias (RN-05) y consolidar costos. Un constructor con muchos parámetros sería ilegible y propenso a errores. |
| **Alternativas consideradas** | *Constructores telescópicos:* descartados por ilegibilidad y errores de orden de parámetros. *Prototype:* descartado (las cajas se componen, no se clonan). |
| **Aplicación concreta** | `BoxBuilder` con métodos fluidos: `.agregarProducto()`, `.aplicarCategoria()`, `.verificarStock()` y `.build()`, que devuelve una `Caja` válida y consistente. |
| **Validación de no solapamiento** | Responsabilidad exclusiva: **construcción progresiva de una entidad compleja**. A diferencia de Factory Method (llamada única), aquí el objeto se arma en varios pasos con reglas de consistencia. |
| **Roles UML → clases BOXLY** | *Builder* → `IBoxBuilder`; *ConcreteBuilder* → `BoxBuilder`; *Product* → `Caja`; *Director* (opcional) → `CajaService` (define la receta según perfil del usuario). |

---

### Patrón 3: Strategy

| Campo | Diligenciamiento |
| --- | --- |
| **Tipo (GoF)** | Comportamiento |
| **Qué es (según la infografía)** | Define una familia de algoritmos, los encapsula y los hace intercambiables. El algoritmo puede variar independientemente de los clientes que lo usan. |
| **Necesidad en BOXLY (MVP)** | La asignación de productos a las cajas depende de la política comercial vigente: por coincidencia de gustos del usuario o por rotación de inventario con alto stock (RN-05, RN-06). La política debe poder cambiarse sin tocar el orquestador. |
| **Alternativas consideradas** | *Lógica condicional en `CajaService`:* descartada porque acopla la clase a todos los algoritmos. *Template Method:* descartado porque la variación debe ser en tiempo de ejecución (inyección), no por subclases. |
| **Aplicación concreta** | Interfaz `IAsignacionStrategy` con `armarCaja(usuario, listaProductos)`; implementaciones `AsignacionPorPreferenciaStrategy` y `AsignacionPorStockStrategy`, inyectadas al orquestador. |
| **Validación de no solapamiento** | Responsabilidad exclusiva: **algoritmos de negocio intercambiables**. No crea el objeto Caja (Builder) ni emite eventos (Observer). |
| **Roles UML → clases BOXLY** | *Strategy* → `IAsignacionStrategy`; *ConcreteStrategy* → `AsignacionPorPreferenciaStrategy`, `AsignacionPorStockStrategy`; *Context* → `CajaService`. |

---

### Patrón 4: Observer

| Campo | Diligenciamiento |
| --- | --- |
| **Tipo (GoF)** | Comportamiento |
| **Qué es (según la infografía)** | Define una dependencia uno-a-muchos entre objetos: cuando un objeto (sujeto) cambia de estado, todos sus dependientes (observadores) son notificados y actualizados automáticamente. |
| **Necesidad en BOXLY (MVP)** | Cuando un `Envio` pasa a «Enviada» o «Entregada» (RN-08) deben ocurrir simultáneamente dos cosas: notificar al usuario por correo y registrar la auditoría. Llamar esos servicios directamente desde `Envio` acoplaría dominio con infraestructura. |
| **Alternativas consideradas** | *Llamadas directas desde `Envio` a Email/Log:* descartadas por acoplamiento fuerte. *Mediator:* descartado (no hay red de colegas; es una difusión pub/sub simple). |
| **Aplicación concreta** | `Envio` es el *Subject* con `notificarObservadores()`; los suscriptores implementan `IEnvioObserver`: `EmailNotifier` y `AuditLogService`. |
| **Validación de no solapamiento** | Responsabilidad exclusiva: **comunicación pub/sub ante cambios de estado**. No define algoritmos de negocio (Strategy) ni construye entidades (Builder). |
| **Roles UML → clases BOXLY** | *Subject* → `Envio`; *Observer* → `IEnvioObserver`; *ConcreteObserver* → `EmailNotifier`, `AuditLogService`. |

---

### Patrón 5: Facade

| Campo | Diligenciamiento |
| --- | --- |
| **Tipo (GoF)** | Estructural |
| **Qué es (según la infografía)** | Proporciona una interfaz unificada a un conjunto de interfaces de un subsistema. Facilita el uso del subsistema al evitar exponer su complejidad interna. |
| **Necesidad en BOXLY (MVP)** | Generar una pre-factura exige coordinar `Plan` (descuentos), `Usuario` (datos), `Envio` (flete) e `Inventario` (reserva). Sin una fachada, el controlador REST queda saturado de coordinaciones (RN-03, RF-10, RF-11). |
| **Alternativas consideradas** | *Acceso directo del controlador a múltiples servicios:* descartado por acoplamiento alto entre presentación y negocio. *Adapter:* descartado (no se adapta una interfaz externa; se simplifica un subsistema propio). *Mediator:* descartado (no hay colaboladores con lógica propia intercambiando mensajes). |
| **Aplicación concreta** | `FacturacionFacade` expone `generarPreFactura(usuarioId, planId)` y devuelve un DTO listo para la vista, coordinando internamente los servicios del subsistema. |
| **Evidencia en el prototipo** | `facturacion.html` consolida en una sola vista valor del plan + descuento + envío = total (RN-03), reflejando la responsabilidad unificada de la fachada. |
| **Validación de no solapamiento** | Responsabilidad exclusiva: **punto de entrada simplificado a un subsistema**. No altera interfaces externas (eso sería Adapter) ni construye objetos paso a paso (Builder). |
| **Roles UML → clases BOXLY** | *Facade* → `FacturacionFacade`; *SubSystem* → `BillingService`, `InventoryService`, `ShippingService`, `PlanRepository`. |

---

## A.4 Validación global de no repetición ni solapamiento

| Patrón | Responsabilidad exclusiva | No invade el territorio de |
| --- | --- | --- |
| Factory Method | Creación de variantes de Plan | Builder, Strategy |
| Builder | Construcción paso a paso de Caja | Factory Method |
| Strategy | Algoritmos intercambiables de asignación | Observer, Builder |
| Observer | Notificación de cambios de estado | Strategy, Facade |
| Facade | Orquestación unificada de pre-facturación | Adapter, Mediator |

Ningún patrón se asigna a dos problemas; cada problema de diseño del MVP tiene exactamente un patrón responsable.

## A.5 Patrones del catálogo GoF descartados (y por qué)

| Patrón descartado | Tipo | Motivo |
| --- | --- | --- |
| Abstract Factory | Creacional | Sobreingeniería: no hay familias de objetos complejas que crear. |
| Prototype | Creacional | No se clonan configuraciones existentes en el MVP. |
| Singleton | Creacional | Su caso de uso (punto único de la pasarela de pagos de terceros) desapareció al simplificar el pago a pre-factura manual (Tabla 1 del documento). |
| Adapter | Estructural | No se integran SDKs externos en el MVP. |
| Proxy / Decorator | Estructural | No se requieren capas de acceso diferido ni decoración en tiempo de ejecución. |
| Template Method | Comportamiento | La variación de algoritmo se resuelve por inyección (Strategy), no por herencia. |
| Mediator | Comportamiento | No hay red de objetos colegas con lógica propia. |
| Chain of Responsibility, Command, Interpreter, Iterator, Memento, State, Visitor | Variados | Sin necesidad equivalente dentro del alcance del MVP. |

---

**Conclusión:** los 5 patrones seleccionados cubren las necesidades creacionales, estructurales y de comportamiento del MVP de Boxly, están trazados a los requisitos del Entregable 1, no se repiten entre sí y evitan sobreingeniería, conforme exige el Entregable No. 2.
