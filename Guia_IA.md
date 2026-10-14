# ProyectoBoxly

Actúa como un Arquitecto de Software y Consultor Senior de UX/UI. Necesito tu ayuda para redactar, desarrollar y refinar el documento técnico final correspondiente al "Entregable No. 2" del curso universitario de Diseño de Sistemas de Información (Institución Universitaria ITM).

### CONTEXTO GENERAL DEL PROYECTO
- **Nombre de la Aplicación:** Boxly (Sistema SaaS de gestión y contratación de cajas de suscripción temáticas: Gaming, Fitness, Cuidado Personal, etc.).
- **Objetivo del proyecto:** Desarrollar un MVP funcional que cubra el ciclo completo de exploración, contratación, pre-facturación y gestión de suscripciones recurrentes.
- **Tecnologías / Herramientas utilizadas:**
  - **Jira Software:** Gestión ágil con 17 Historias de Usuario (HU) estructuradas en 4 Épicas.
  - **Figma:** Prototipo funcional navegable en alta fidelidad (Paleta: Índigo `#4F46E5` y Blanco).
  - **Frontend:** Aplicación web en React / TypeScript en GitHub.

---

### ESTRUCTURA DEL BACKLOG (17 HUs en 4 ÉPICAS)
1. **Épica 1: Catálogo y Exploración de Suscripciones**
   - HU-1.1: Visualización del catálogo general de cajas.
   - HU-1.2: Búsqueda y filtrado por categorías.
   - HU-1.3: Consulta de detalle de producto/caja.
   - HU-1.4: Histórico de entregas previas.
   - HU-1.5: Comparador de planes de suscripción.
2. **Épica 2: Onboarding y Gestión de Perfil**
   - HU-2.1: Registro de usuario.
   - HU-2.2: Inicio de sesión seguro.
   - HU-2.3: Configuración de perfil y preferencias.
   - HU-2.4: Gestión de direcciones y métodos de pago.
3. **Épica 3: Suscripción y Logística**
   - HU-3.1: Proceso de contratación y pre-facturación.
   - HU-3.2: Procesamiento de pago recurrente.
   - HU-3.3: Seguimiento de envíos.
   - HU-3.4: Pausa, cancelación o cambio de plan.
4. **Épica 4: Panel de Administración (Backoffice)**
   - HU-4.1 a HU-4.6: Gestión de catálogo, alertas de stock, administración de clientes y Dashboard de analítica (MRR, Churn Rate).

---

### FLUJO PRINCIPAL DEL PROTOTIPO (HAPPY PATH EN FIGMA)
El prototipo navega de forma continua a través de 4 pantallas clave:
1. **Catálogo General (Tienda):** Exploración y filtros por categoría.
2. **Detalle de Caja:** Selección del plan (Mensual vs. Anual con descuento).
3. **Checkout y Prefacturación:** Dirección de envío, método de pago y desglose del costo total.
4. **Dashboard de Cliente ("Mis Suscripciones"):** Confirmación con la nueva caja en estado "Activa".

---

### REQUERIMIENTOS ESPECÍFICOS DEL ENTREGABLE #2
El documento debe consolidar y evolucionar lo realizado en el Entregable #1 (no reemplazarlo) bajo las siguientes secciones obligatorias:

1. **Sección 0: Portada** (Datos institucionales del ITM).
2. **Sección 1: Refinamiento del Entregable #1 en el Entregable #2** (Incluye la Tabla 1 con columnas: *Elemento ajustado*, *Cómo estaba antes*, *Cómo quedó refinado* y *Motivo del ajuste*).
3. **Sección 2: Arquitectura C4** (Explicación y estructura para Nivel 1: Contexto, Nivel 2: Contenedores, Nivel 3: Componentes y Nivel 4: Código/Clases).
4. **Sección 3: Patrones de Diseño GoF (5 patrones no repetidos y justificados para el MVP):**
   - *Strategy Pattern:* Para cálculo dinámico de cobros y descuentos de planes.
   - *Factory Method:* Para instanciación parametrizada de tipos de cajas.
   - *Observer Pattern:* Para el sistema de notificaciones de estado del envío.
   - *Repository Pattern:* Para desacoplar el acceso a datos del catálogo/suscripciones.
   - *Singleton Pattern:* Para el punto único de configuración de la pasarela de pagos.
5. **Sección 4: Prototipo Funcional** (Sustentación del Happy Path y enlace a Figma).
6. **Sección 5: Diagrama de Actividades del MVP** (Flujo detallado de decisiones en la pre-facturación).
7. **Sección 6: Aplicación de Principios SOLID** (Análisis aplicado a componentes reales del sistema: SRP, OCP, LSP, ISP, DIP).
8. **Sección 7: Anexos y Enlaces** (Repositorio de GitHub, enlace a Figma y diagramas editables).

---

### TU TAREA
Con base en todo este contexto de Boxly, ayúdame a verificar lo actualmente construido, luego ayuda en el frontend en la parte de "Bonos", puedes apoyarte en imagenes que te envíe
