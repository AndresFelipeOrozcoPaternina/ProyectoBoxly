# Anexo B — Plantilla de Análisis de Principios SOLID (diligenciada)

**Proyecto:** Boxly — Entregable No. 2
**Curso:** Diseño de Sistemas de Información — ITM
**Alcance:** análisis aplicado a componentes reales del sistema, evidenciando la evolución entre el Entregable 1 (diseño conceptual) y el Entregable 2 (arquitectura C4 + prototipo funcional).

---

## B.1 Matriz resumen

| Principio | Componente BOXLY | Diseño previo (problema) | Refinamiento (solución) | Trazabilidad |
| --- | --- | --- | --- | --- |
| **S** — Single Responsibility | `Suscripcion` | Calculaba planes, persistía y notificaba a la vez | Dominio puro + `SuscripcionRepository`, `FacturacionFacade`, `EmailNotifier` | RF-10 a RF-13, RN-04 |
| **O** — Open/Closed | `CajaService` / `IAsignacionStrategy` | Cambiar política de empaquetado exigía editar código existente | Nueva estrategia = nueva clase, sin modificar el orquestador | RF-04, RN-05, RN-06 |
| **L** — Liskov Substitution | `Persona` → `Usuario` / `Administrador` | Riesgo de comprobaciones de tipo (`if is Administrador`) | Polimorfismo seguro sobre el contrato `iniciarSesion()` | RF-01 a RF-03, RNF-01 |
| **I** — Interface Segregation | Servicios del cliente y del admin | Interfaz masiva `IGestionSistema` para todos los roles | `IClienteService`, `IAdminInventoryService`, `IAdminBillingService` | RF-05 a RF-13 vs RF-14 a RF-18 |
| **D** — Dependency Inversion | `BillingService` | Instanciaba concretos de persistencia y notificación | Depende de `INotificationService` y repositorios abstractos (DI de ASP.NET Core) | RF-10, RF-11, RNF-09 |

---

## B.2 Análisis por principio

### S — Single Responsibility Principle

| Campo | Diligenciamiento |
| --- | --- |
| **Definición** | Una clase debe tener una sola razón para cambiar. |
| **Componente analizado** | Entidad `Suscripcion` del modelo de dominio (Nivel 4 del C4). |
| **Diseño previo (Entregable 1)** | `Suscripcion` realizaba tres tareas: calcular costos de plan, persistir registros en base de datos y enviar correos de notificación. Cualquier cambio de infraestructura tocaba la entidad de dominio. |
| **Refinamiento (Entregable 2)** | `Suscripcion` conserva solo datos y reglas puras del dominio (fechas, estado, relación con `Plan`). La persistencia se delega a `SuscripcionRepository`; la emisión de comprobantes a `FacturacionFacade`; las notificaciones a `EmailNotifier` (suscriptor del patrón Observer). |
| **Beneficio** | Un cambio en el ORM o en el proveedor de correo no afecta la entidad de dominio ni su prueba unitaria. |
| **Evidencia en el flujo implementado** | En `facturacion.html`, la confirmación de la pre-factura y la activación de la suscripción son responsabilidades separadas (generar documento vs. cambiar estado), reflejo de esta separación. |

### O — Open/Closed Principle

| Campo | Diligenciamiento |
| --- | --- |
| **Definición** | Las entidades de software deben estar abiertas a la extensión pero cerradas a la modificación. |
| **Componente analizado** | Orquestador de armado de cajas (`CajaService`) con la abstracción `IAsignacionStrategy` (patrón Strategy). |
| **Diseño previo (Entregable 1)** | La lógica de asignación de productos vivía en condicionales dentro del servicio; cada nueva política comercial exigía editar esa clase ya probada. |
| **Refinamiento (Entregable 2)** | Para agregar un nuevo criterio (ej. `AsignacionPorCajasTematicasStrategy`) no se modifica la clase procesadora: se crea una nueva clase que implementa `IAsignacionStrategy` y se inyecta. |
| **Beneficio** | Nuevas reglas de negocio sin riesgo de romper comportamiento existente; despliegue incremental de políticas comerciales. |
| **Trazabilidad** | RF-04, RN-05, RN-06 (asignación según preferencias e inventario). |

### L — Liskov Substitution Principle

| Campo | Diligenciamiento |
| --- | --- |
| **Definición** | Las subclases deben poder sustituir a sus clases base sin alterar el comportamiento correcto del programa. |
| **Componente analizado** | Jerarquía `Persona` (abstracta) ← `Usuario`, `Administrador` (Nivel 4 del C4; hereda el diagrama de clases del Entregable 1). |
| **Diseño previo (Entregable 1)** | El control de acceso podía degradar en comprobaciones explícitas de tipo (`if (p is Administrador)`) repartidas por el código. |
| **Refinamiento (Entregable 2)** | `Persona` define el contrato común `iniciarSesion()` / `actualizacionDatos()`. El módulo de seguridad trata cualquier instancia de `Persona` de forma polimórfica, sin preguntar el tipo concreto. |
| **Beneficio** | Sustitución segura: nuevos roles (ej. `Soportista`) podrán integrarse sin romper el control de acceso. |
| **Trazabilidad** | RF-01 a RF-03, RNF-01 (autorización). |

### I — Interface Segregation Principle

| Campo | Diligenciamiento |
| --- | --- |
| **Definición** | Los clientes no deben ser obligados a depender de interfaces que no utilizan. |
| **Componente analizado** | Contratos de servicio expuestos al frontend de cliente y al backoffice (Nivel 3 del C4). |
| **Diseño previo (Entregable 1)** | Una interfaz masiva `IGestionSistema` forzaba a los consumidores del cliente a conocer métodos administrativos como `actualizarStock()` o `aprobarPagoManual()`. |
| **Refinamiento (Entregable 2)** | Segregación por dominio de uso: `IClienteService` (catálogo, suscripción, rastreo), `IAdminInventoryService` (stock e insumos), `IAdminBillingService` (validación de pre-facturas y pagos). |
| **Beneficio** | Desacoplamiento total: la UI del cliente no depende ni se entera de las operaciones de administración; menos superficie de error en la integración. |
| **Trazabilidad** | RF-05 a RF-13 (cliente) frente a RF-14 a RF-18 (administrador). |

### D — Dependency Inversion Principle

| Campo | Diligenciamiento |
| --- | --- |
| **Definición** | Los módulos de alto nivel no deben depender de módulos de bajo nivel; ambos deben depender de abstracciones. |
| **Componente analizado** | `BillingService` (módulo de negocio de facturación, Nivel 3 del C4). |
| **Diseño previo (Entregable 1)** | `BillingService` instanciaba directamente clases concretas de infraestructura (repositorio SQL, servicio de correo), lo que impedía el testing con mocks. |
| **Refinamiento (Entregable 2)** | `BillingService` depende de abstracciones (`INotificationService`, `IRepositorioSuscripcion`). Las implementaciones concretas se inyectan con el contenedor de DI nativo de ASP.NET Core (`IServiceCollection`). |
| **Beneficio** | Pruebas unitarias con mocks, sustitución de tecnologías (p. ej. otro proveedor de correo) sin impactar la lógica de negocio. |
| **Trazabilidad** | RF-10, RF-11, RNF-09 (mantenibilidad modular). |

---

## B.3 Trazabilidad con la evolución Entregable 1 → Entregable 2

| Principio | Insumo del Entregable 1 | Materialización en el Entregable 2 |
| --- | --- | --- |
| S | Reglas de negocio RN-03, RN-04, RN-12 | Separación Suscripcion / FacturacionFacade / EmailNotifier en el Nivel 4 del C4 |
| O | RF-04, RN-05, RN-06 | Estrategias de asignación descritas en el Nivel 3 y sustentadas por el MVP de cajas |
| L | Diagrama de clases inicial (herencia Persona) | Jerarquía refinada Nivel 4 con contrato polimórfico de autenticación |
| I | RU-01 a RU-05 vs RF-01 a RF-19 | Interfaces segregadas por rol cliente/administrador en el Nivel 3 |
| D | RNF-09 (mantenibilidad) | Inyección de Dependencias nativa de ASP.NET Core descrita en la Tabla 1 |

---

**Conclusión:** los principios SOLID no se aplican sobre ejemplos aislados: cada uno está anclado a un componente del modelo C4 de Boxly, con su problema previo del Entregable 1, su refinamiento en el Entregable 2 y su trazabilidad a requisitos y reglas de negocio.
