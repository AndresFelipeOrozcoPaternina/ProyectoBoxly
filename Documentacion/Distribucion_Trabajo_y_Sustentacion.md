# 👥 Distribución del Trabajo y Guion de Sustentación (15 Minutos)

**Proyecto:** Boxly — Plataforma SaaS de Suscripción a Cajas Temáticas  
**Asignatura:** Diseño de Sistemas de Información — ITM  
**Docente:** Alexandra Guerrero Bocanegra  
**Fecha:** Noviembre de 2026  

---

## 📌 1. Resumen de Contribuciones por Integrante

| Integrante | Rama Git | N° Commits | Responsabilidad Técnica Principal |
| :--- | :---: | :---: | :--- |
| **Andrés Felipe Orozco Paternina** | `feature/estados-refinamiento` | 5 | **Refinamiento E1/E2 y Máquina de Estados UML:**<br>• Diligenciamiento de la Sección 1 (Tabla 1 de ajustes y Tabla 2 de evidencias).<br>• Modelado de la Máquina de Estados de la entidad `Suscripcion`.<br>• Elaboración de la matriz de transiciones, guardas `[pago.aprobado]` y acciones `entry /`.<br>• Creación del diagrama editable `.drawio` y vectorial `.svg`. |
| **Juan David Restrepo Alvarez** / **Jesús David Ávila Arrieta** | `feature/componentes-secuencia` | 5 | **Arquitectura de Software y Diagramas de Secuencia:**<br>• Diseño del Diagrama UML de Componentes (separación API, servicios, repositorios).<br>• Diseño del Diagrama UML de Despliegue (puertos locales, Live Server y ASP.NET Core).<br>• Modelado de Secuencia para Épica 1 (Catálogo y Detalle con fragmentos `loop`).<br>• Modelado de Secuencia para Épica 3 (Contratación con fragmentos `alt` para flujos 400, 404, 409, 422 y 201). |
| **Jose Manuel Pulgarin Rueda** | `rama-jose` | 8+ | **Backend Web API (.NET 10), Patrones GoF, SOLID y Frontend UX:**<br>• Implementación de la solución ASP.NET Core Web API en C#.<br>• Implementación en código de los 5 patrones GoF (*Factory Method*, *Builder*, *Strategy*, *Observer*, *Facade*) y principios SOLID.<br>• Implementación de controladores REST con manejo de flujos alternativos (400, 404, 409, 422, 200).<br>• Creación de la Suite de Pruebas Automatizadas (10/10 PASS).<br>• Refinamiento UX del frontend: rechazo bancario estricto (CVC `000`), retiro de cajas canceladas y transporte al catálogo en `inicio.html`. |

---

## ⏱️ 2. Guion de Sustentación en Vivo (15 Minutos)

El tiempo se divide de manera equitativa entre los integrantes para demostrar dominio individual y colectivo del sistema:

```
[0:00 - 4:00]  PARTE 1: Evolución del Sistema y Máquina de Estados
[4:00 - 8:00]  PARTE 2: Arquitectura (Componentes, Despliegue) y Secuencias
[8:00 - 15:00] PARTE 3: Demostración en Vivo del MVP, Patrones GoF y Flujos Alternativos
```

---

### 🎙️ Parte 1 (Minutos 0:00 – 4:00) — Andrés Felipe Orozco Paternina
**Objetivo:** Explicar cómo evolucionó el sistema y cómo se comporta la entidad central.

* **Qué dice (Sin rodeos):**
  1. *"Buenas tardes profesora. En este Entregable 3 consolidamos los requisitos de E1 y la arquitectura de E2 en un sistema funcional. En la Sección 1 demostramos qué conservamos y qué simplificamos para el MVP (como mantener los repositorios en memoria para no meter sobreingeniería de bases de datos antes de tiempo)."*
  2. *"Para modelar el comportamiento del sistema, analizamos el ciclo de vida de la entidad `Suscripcion` mediante una **Máquina de Estados UML**."*
* **Qué muestra en pantalla:**
  - El diagrama `maquina-estados-suscripcion.svg` y la tabla de transiciones.
* **Puntos clave que debe resaltar:**
  - Inicia en `PendientePago`.
  - Si el pago es aprobado (`[pago.aprobado]`), pasa a `Activa` (ejecutando `entry / guardarYNotificar()`).
  - Si el banco lo rechaza (`[!pago.aprobado]`), pasa a `PagoRechazado` (**RN-04**), no activa la caja ni descuenta inventario.
  - El usuario puede cancelar desde activa o rechazada y termina en `Cancelada` (símbolo final del ciclo).

---

### 🎙️ Parte 2 (Minutos 4:00 – 8:00) — Juan David Restrepo / Jesús David Ávila
**Objetivo:** Explicar la distribución física, los componentes internos y las interacciones entre capas.

* **Qué dice (Sin rodeos):**
  1. *"Pasando a la arquitectura de software, diseñamos dos vistas complementarias: el **Diagrama de Componentes** y el **Diagrama de Despliegue**."*
  2. *"En componentes se evidencia la separación limpia: el frontend se comunica vía HTTP con los controladores de ASP.NET Core (`SuscripcionesController` y `CajasController`). Estos delegan las reglas al `SuscripcionService`, el cual coordina la `FacturacionFacade`, los repositorios y el `SuscripcionNotifier` con Inyección de Dependencias."*
  3. *"En los **Diagramas de Secuencia**, mostramos las interacciones dinámicas. Para la Épica 1 usamos fragmentos `loop` para el filtrado en cliente, y para la Épica 3 (Contratación) usamos fragmentos `alt` para representar los caminos alternativos: 400 por datos inválidos, 404 si la caja no existe, 409 si no hay stock, y 422 si el pago es rechazado."*
* **Qué muestra en pantalla:**
  - Diagramas `arquitectura-componentes.svg`, `arquitectura-despliegue.svg` y `secuencia-epica-3-contratacion.svg`.
* **Puntos clave que debe resaltar:**
  - Los diagramas corresponden exactamente al código existente (mismos nombres de clases e interfaces).
  - La arquitectura es desacoplada y basada en principios SOLID.

---

### 🎙️ Parte 3 (Minutos 8:00 – 15:00) — Jose Manuel Pulgarin Rueda
**Objetivo:** Demostrar el MVP en vivo, la ejecución de la suite de pruebas y los patrones GoF en código.

* **Paso 1: Ejecutar la Suite de Pruebas Automatizadas (Terminal)**
  - Ejecuta:
    ```bash
    dotnet run --project backend/Boxly.Api -- --verify-suite
    ```
  - **Qué dice:** *"Para validar de forma determinista las reglas de negocio y los 5 patrones GoF, implementamos un runner de pruebas automatizadas. Como pueden observar en consola, pasa 10 de 10 pruebas exitosas sin errores: verifica los descuentos de Factory Method (RN-11), las validaciones de Builder (RN-05), la prefactura de Facade (RN-03), el Happy Path (201) y los 4 flujos alternativos (404, 422, cancelación e idempotencia)."*

* **Paso 2: Mostrar los Patrones GoF en el Código (VS Code / Editor)**
  - Abre rápidamente la carpeta `backend/Boxly.Api/Patterns/`:
    - `PlanFactory.cs`: Muestra cómo calcula 0%, 10% y 20% de descuento polimórficamente sin condicionales.
    - `FacturacionFacade.cs`: Muestra cómo une el costo de envío fijo ($15.000) y la validación de la tarjeta.
    - `SuscripcionObserver.cs`: Muestra el desacoplamiento de los eventos de correo y auditoría.

* **Paso 3: Demostración en el Navegador (Flujo Alternativo 422 y Happy Path)**
  - **Prueba de Rechazo Bancario (Flujo Alternativo 422 - RN-04):**
    - Abre `facturacion.html`.
    - Escribe CVC `000` y haz clic en *Confirmar pre-factura*.
    - **Qué dice:** *"Miren cómo el sistema detecta de inmediato el fallo bancario, bloquea la activación de la suscripción y despliega la alerta roja de Flujo Alternativo 422 en pantalla sin redireccionar ni cobrar."*
  - **Prueba del Happy Path (201 Created):**
    - Cambia el CVC a `123` y confirma.
    - Se genera la pre-factura, se aprueba el cobro y redirige a `cajas.html` con el banner verde de suscripción confirmada.
  - **Prueba de Cancelación y Transporte a Inicio (Flujo Alternativo de Ciclo de Vida):**
    - Abre los detalles de la caja y haz clic en *Cancelar suscripción*.
    - **Qué dice:** *"Al cancelar, la suscripción se desactiva en el backend, se retira de la lista de 'Mis cajas' y el sistema transporta automáticamente al usuario al catálogo en `inicio.html`, mostrando el aviso de que la caja vuelve a estar disponible para explorar."*

---

## 🎯 3. Preguntas Frecuentes del Docente y Respuestas Directas

* **¿Por qué usaron repositorios en memoria y no conectaron PostgreSQL todavía?**
  > *"Porque para el alcance del MVP del Entregable 3 la rúbrica exigía validar reglas de negocio, patrones GoF y flujos alternativos. Conectar una base de datos externa introducía dependencias de infraestructura innecesarias sin aportar valor a la lógica del dominio, la cual ya está completamente desacoplada mediante la interfaz `ISuscripcionRepository` lista para enchufar Entity Framework en la siguiente fase."*

* **¿Dónde se evidencia el principio Open/Closed (OCP)?**
  > *"En `PlanFactory` y en `IAsignacionStrategy`: si mañana el negocio lanza un 'Plan Trimestral' o una estrategia de empaquetado 'Black Friday', solo creamos una nueva clase derivada sin tocar ni arriesgar el código que ya funciona."*

* **¿Qué diferencia hay entre el Happy Path y el Flujo Alternativo 422?**
  > *"En el Happy Path el banco aprueba el pago, la suscripción pasa al estado `Activa` (RN-04) y se descuenta stock. En el 422, la pasarela declina la transacción, la suscripción queda registrada como `PagoRechazado`, no se descuenta inventario y el frontend alerta al cliente sin activar el servicio."*
