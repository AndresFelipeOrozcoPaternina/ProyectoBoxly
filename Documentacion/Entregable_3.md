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

En esta sección, el equipo debe presentar la versión actualizada y funcional del MVP, incorporando los flujos alternativos, validaciones y escenarios de excepción correspondientes a las funcionalidades implementadas. 

A diferencia del Entregable No. 2, esta entrega debe demostrar no solamente el funcionamiento del flujo principal, sino también el comportamiento del sistema ante situaciones alternativas, entradas inválidas y restricciones del negocio. 

El equipo debe evidenciar la implementación del backend y la aplicación justificada de los patrones GoF y principios SOLID analizados previamente. 

El MVP debe evidenciar: 

- Funcionalidades implementadas y operativas 

- Ejecución completa de los flujos principales 

- Flujos alternativos implementados y verificables 

- Validación de datos de entrada 

- Manejo controlado de errores y excepciones 

- Aplicación de reglas de negocio 

- Persistencia de información, cuando corresponda 

- Integración entre frontend, backend y demás componentes 

- Aplicación pertinente de patrones GoF y principios SOLID 

- Coherencia entre código fuente, diagramas UML y arquitectura C4 

- - Estabilidad durante la demostración funcional 

El equipo debe entregar: 

- Descripción de las funcionalidades implementadas 

- - Relación con las historias de usuario o casos de uso 

ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

- Capturas de pantalla de los principales procesos 

- Evidencias del funcionamiento de los flujos principales y alternativos 

- Descripción de las validaciones y excepciones implementadas 

- Tecnologías utilizadas 

- Instrucciones para ejecutar el MVP 

- Referencias a las clases o componentes donde se evidencien las decisiones de diseño 

**Importante:** Los flujos alternativos deben encontrarse implementados en el código y ser demostrables. No será suficiente describirlos en el documento o representarlos únicamente en los diagramas. 

# **6. Repositorio Git** 

En esta sección, el equipo debe presentar el repositorio Git actualizado, evidenciando la evolución del código fuente, la organización del proyecto y la participación técnica de sus integrantes. 

El repositorio debe incluir: 

- Código fuente actualizado del MVP 

- Organización coherente de carpetas, módulos y componentes 

- Archivo README.md completo 

- Archivos de configuración y dependencias necesarios 

- Documentación técnica mínima 

- Enlaces a los diagramas y demás artefactos 

- Historial de commits verificable 

- Evidencia de participación de los integrantes 

- Buenas prácticas de versionamiento 

Requisitos mínimos del historial de commits: 

Cada integrante deberá registrar mínimo cinco commits significativos y verificables, correspondientes al trabajo desarrollado para el Entregable No. 3. 

Los commits deben cumplir las siguientes condiciones: 

- Reflejar cambios reales en código, documentación técnica, pruebas o configuración 

- Tener mensajes descriptivos que permitan identificar el trabajo realizado 

- Estar asociados a la cuenta Git del integrante responsable 

- Evidenciar progresión del trabajo durante el desarrollo 

- Evitar commits vacíos, duplicados o modificaciones artificiales para cumplir la cantidad 

- Estar integrados en la rama principal o en ramas de trabajo identificables y verificables 

El equipo debe presentar una tabla de seguimiento con el integrante, número de commits, principales contribuciones y enlace al historial correspondiente. 

ENTREGABLE #3 DISEÑO DE SISTEMAS DE INFORMACIÓN 

**Criterio de evaluación** . El cumplimiento del mínimo de cinco commits por integrante será un requisito verificable. Sin embargo, la valoración tendrá en cuenta la calidad, pertinencia y trazabilidad de las contribuciones. Alcanzar el mínimo no garantiza la máxima calificación. 

Contenido mínimo del README.md: 

- Nombre y descripción del proyecto 

- Integrantes del equipo 

- Tecnologías utilizadas 

- Arquitectura general de la solución 

- Funcionalidades implementadas 

- Requisitos de instalación 

- Configuración del entorno y dependencias 

- Instrucciones para ejecutar frontend y backend 

- Enlace al despliegue, cuando corresponda 

- Enlaces a la documentación técnica y diagramas 

- Evidencias del MVP 

# **7. Anexos** 

En esta sección, el equipo debe incluir las evidencias complementarias que permitan verificar los artefactos y funcionalidades desarrolladas. 

# Debe incluir: 

- Enlace al repositorio Git 

- Enlace al prototipo en Figma 

- Enlaces editables de los diagramas UML 

- Capturas adicionales del MVP 

- Evidencias de ejecución de flujos principales y alternativos 

- Evidencia del historial de commits y participación individual 

- Documentación técnica complementaria 

- Referencias bibliográficas utilizadas 

Los anexos deben estar organizados, identificados y referenciados desde las secciones correspondientes del documento. 

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

