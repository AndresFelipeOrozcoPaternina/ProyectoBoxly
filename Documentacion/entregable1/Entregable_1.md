# **BOXLY** 

# **Proyecto de Diseño de Sistemas de Información** 

Andrés Felipe Orozco Paternina 

Jose Manuel Pulgarin Rueda 

Juan David Restrepo Alvarez 

Jesús David Ávila Arrieta 

Docente: Alexandra Guerrero Bocanegra 

Curso: Diseño de Sistemas de Información 

Fecha: 31 de agosto de 2026 

Institución: ITM 

## **1. Modelo Verbal del Sistema** 

### **Contexto del problema** 

El proyecto consiste en desarrollar una plataforma de suscripción a cajas de productos, donde los usuarios puedan conocer las diferentes cajas disponibles, consultar su contenido y elegir un plan de suscripción. Además, podrán crear un perfil con sus preferencias para recibir productos relacionados con sus gustos. 

Actualmente, realizar estos procesos de forma manual puede generar dificultades para organizar las suscripciones, controlar el inventario, preparar las cajas, gestionar los pagos y hacer seguimiento a los envíos. 

### **Problema actual** 

Uno de los principales problemas es la falta de una plataforma que centralice la información de los usuarios, cajas, planes, productos, pagos y envíos. Esto puede ocasionar errores en el inventario, dificultades para personalizar las cajas, problemas en la gestión de suscripciones y poca información sobre el estado de los pedidos. 

### **Causas identificadas** 

- Procesos manuales para gestionar las suscripciones y cajas. 

- Falta de un catálogo organizado de productos y cajas. 

- Dificultad para conocer las preferencias de cada usuario. 

- Control poco eficiente del inventario. 

- Falta de automatización para asignar productos a las cajas. 

- Dificultad para controlar pagos, pre-facturas y envíos. 

- Falta de estadísticas para apoyar las decisiones del negocio. 

- Impacto en el negocio y los usuarios 

Estos problemas pueden generar pérdida de tiempo, errores en la preparación de las cajas, falta de productos y retrasos en los envíos. Para los usuarios, puede resultar difícil encontrar una caja adecuada, conocer los costos, controlar sus pagos y saber en qué estado se encuentra su pedido. 

Para el negocio, también se dificulta conocer información importante como las categorías más solicitadas, los ingresos recurrentes y la cantidad de usuarios activos o cancelado 

### **Flujo actual del proceso** 

De manera general, el proceso funciona de la siguiente forma: 

- El usuario consulta las cajas disponibles y sus temáticas. 

- Busca o filtra una caja según sus intereses. 

- Consulta el contenido, precios y costos de envío. 

- Selecciona un plan de suscripción. 

- Crea su cuenta y registra sus preferencias. 

- Se genera una pre-factura con el detalle y costo de la suscripción. 

- El usuario confirma el pago. 

- El administrador revisa las suscripciones activas y el inventario. 

- Se asignan los productos para cada caja según las preferencias del usuario. 

- Se prepara y despacha la caja. 

- El usuario consulta el estado del envío hasta recibirlo. 

### **Propuesta general de solución** 

Se propone desarrollar una plataforma que permita gestionar todo el proceso de suscripción de manera centralizada. Los usuarios podrán explorar las cajas, consultar su contenido, comparar planes y precios, crear su perfil con preferencias, revisar sus pre-facturas y realizar seguimiento de sus envíos. 

Por otro lado, los administradores podrán gestionar usuarios, productos, inventario, planes, precios y cajas. También podrán actualizar los estados de los envíos y consultar estadísticas del negocio. 

## **1.1 Requisitos de Usuario** 

|**ID. Requisito**|**Nombre del Requisito**|**Descripción del Requisito**|
|---|---|---|
|RU-01|Exploración de<br>catálogo y planes|El usuario necesita consultar las cajas<br>disponibles, buscar opciones por temática,<br>revisar el contenido y comparar los planes de<br>suscripción para tomar una decisión.|
|RU-02|Registro y<br>personalización de<br>perfil|El usuario necesita crear una cuenta en la<br>plataforma y registrar sus intereses para<br>garantizar que los productos asignados a su<br>caja coincidan con sus preferencias.|
|RU-03|Gestión de<br>pre-facturación y<br>seguimiento logístico|El usuario necesita validar el costo de su<br>suscripción mediante una pre-factura, confirmar<br>el pago y rastrear el estado de su envío hasta<br>recibirlo|
|RU-04|Operación de<br>inventario y logística|El administrador necesita garantizar la revisión<br>de suscripciones activas, actualizar el<br>inventario, asignar productos a las cajas y<br>gestionar el estado de lo despachos|
|RU-05|Configuración<br>comercial y métricas|El administrador necesita gestionar la creación<br>de cajas, definir los precios de los planes y<br>consultar estadísticas generales para apoyar<br>las decisiones del negocio.|



## **1.2 Requisitos de Sistema – Funcionales** 

|**ID.**<br>**Requisito**|**Nombre del**<br>**Requisito**|**Descripción del Requisito**|**Usuario/Rol**|
|---|---|---|---|
|**RF-01**|Registro de<br>usuario|El sistema debe permitir al usuario<br>crear una cuenta ingresando sus datos<br>personales y de acceso.|Usuario|
|**RF-02**|Inicio de sesión|El sistema debe permitir al usuario<br>iniciar sesión para acceder a su<br>cuenta.|Usuario|
|**RF-03**|Gestión de perfil|El sistema debe permitir al usuario<br>consultar y modificar sus datos<br>personales.|Usuario|
|**RF-04**|Selección de<br>preferencias|El sistema debe permitir al usuario<br>seleccionar sus categorías de<br>productos preferidas.|Usuario|
|**RF-05**|Catálogo de<br>cajas|El sistema debe mostrar las cajas<br>disponibles con su nombre, precio y<br>temática.|Usuario|
|**RF-06**|Buscar cajas|El sistema debe permitir al usuario<br>buscar cajas por nombre o categoría.|Usuario|
|**RF-07**|Detalle de caja|El sistema debe mostrar la descripción<br>y los productos incluidos en una caja.|Usuario|
|**RF-08**|Consulta de<br>planes|El sistema debe mostrar los planes de<br>suscripción disponibles y sus precios.|Usuario|
|**RF-09**|Selección de<br>plan|El sistema debe permitir al usuario<br>seleccionar un plan de suscripción.|Usuario|
|**RF-10**|Generación de<br>pre-factura|El sistema debe generar una<br>pre-factura mostrando el plan<br>seleccionado y el costo total.|Usuario|
|**RF-11**|Registro de<br>pago|El sistema debe permitir registrar el<br>pago correspondiente a una<br>suscripción.|Usuario|
|**RF-12**|Consulta de<br>pre-facturas|El sistema debe permitir al usuario<br>consultarsus pre-facturas anteriores.|Usuario|
|**RF-13**|Consulta del<br>estado del envío|El sistema debe permitir al usuario<br>consultar si su caja está en<br>preparación, enviada o entregada.|Usuario|
|**RF-14**|Gestión de<br>usuarios|El sistema debe permitir al<br>administrador consultar los usuarios<br>registrados y sus suscripciones.|Administrador|
|**RF-15**|Gestión de<br>productos|El sistema debe permitir al<br>administrador agregar, modificar y<br>eliminar productos.|Administrador|
|**RF-16**|Gestión de<br>inventario|<br>El sistema debe permitir al<br>administrador consultar y actualizar la<br>cantidad disponible de cada producto.|Administrador|
|**RF-17**|Gestión de<br>planes|<br>El sistema debe permitir al<br>administrador crear y modificar los<br>planes y sus precios.|Administrador|



|**RF-18**|Gestión de cajas|El sistema debe permitir al<br>administrador crear y modificar las<br>cajas y los productos que contienen.|Administrador|
|---|---|---|---|
|**RF-19**|_Dashboard de_<br>_métricas y_<br>_estadísticas_|El sistema debe permitir al<br>administrador visualizar un tablero con<br>indicadores clave del negocio (usuarios<br>activos, ingresos mensuales, tasa de<br>cancelación y categorías más<br>demandadas).|Administrador|



## **1.3 Requisitos de Sistema – No Funcionales** 

|**ID. Requisito**|**Tipo de RNF**|**Descripción del Requisito**|
|---|---|---|
|RNF-01|Seguridad|El sistema debe asegurarse de que cada persona<br>pueda acceder solamente a las funciones que le<br>corresponden.|
|RNF-02|Seguridad|El sistema deberá proteger los datos personales y<br>de acceso de los usuarios, evitando que puedan ser<br>consultados o modificados por usuarios no<br>autorizados.|
|RNF-03|Rendimiento|El sistema deberá mostrar las páginas de catálogo,<br>planes y perfil en un tiempo máximo de 5 segundos<br>bajo condiciones normales de operación.|
|RNF-04|Disponibilidad|La plataforma deberá estar disponible para los<br>usuarios durante el periodo de operación definido<br>por el negocio, permitiendo consultar el catálogo,<br>perfil, pagos y estado de los envíos.|
|RNF-05|Usabilidad|La interfaz deberá permitir al usuario consultar las<br>cajas, aplicar filtros, revisar los planes y seleccionar<br>una suscripción sin requerir conocimientos técnicos<br>especializados.|
|RNF-06|Integridad de<br>datos|El sistema deberá mantener consistentes los datos<br>relacionados con usuarios, suscripciones, pagos,<br>productos, inventario y envíos, evitando registros<br>incompletos o inconsistentes.|
|RNF-07|Escalabilidad|El sistema deberá permitir incorporar nuevas cajas,<br>productos, categorías y planes de suscripción sin<br>requerir modificaciones estructurales importantes en<br>la información existente.|
|RNF-08|Compatibilidad|La plataforma deberá ser accesible desde los<br>navegadores web utilizados habitualmente por los<br>usuarios, manteniendo la correcta visualización de<br>sus funcionalidades principales.|
|RNF-09|Mantenibilidad|El sistema deberá estar organizado de manera<br>modular, permitiendo realizar modificaciones en<br>funcionalidades como catálogo, suscripciones,|



|||inventario y logística sin afectar innecesariamente<br>los demás módulos.|
|---|---|---|
|RNF-10|Trazabilidad|El sistema deberá conservar el historial de las<br>pre-facturas y permitir consultar el estado de los<br>envíos asociados a las suscripciones de los<br>usuarios.|



## **1.4 Reglas de Negocio** 

|**ID. RN**|**Descripción**|
|---|---|
|RN-01|Todo usuario debe estar registrado e iniciar sesión para poder adquirir un plan<br>de suscripción, registrar preferencias, consultar pre-facturas y realizar<br>seguimiento de sus envíos.|
|RN-02|Un usuario solo puede tener una suscripción activa por periodo mensual. Si ya<br>existe una suscripción activa, el sistema no permitirá crear otra para el mismo<br>periodo.|
|RN-03|La pre-factura debe generarse automáticamente al seleccionar un plan y debe<br>incluir el valor del plan, el costo de envío (si aplica) y el total a pagar antes de<br>confirmar la compra.|
|RN-04|La suscripción solo se activará cuando el pago sea registrado y validado por el<br>sistema o por un administrador.|
|RN-05|Las cajas mensuales se asignarán automáticamente según las preferencias<br>registradas por el usuario y la disponibilidad de inventario.|
|RN-06|Un producto solo podrá incluirse en una caja si existe inventario suficiente para<br>cubrir las suscripciones activas.|
|RN-07|El inventario debe disminuir automáticamente cuando una caja sea preparada<br>para envío.|
|RN-08|Los estados logísticos de una caja deben seguir el orden: Preparando →<br>Enviada → Entregada. No se permite cambiar directamente de Preparando a<br>Entregada.|
|RN-09|El usuario únicamente podrá consultar las pre-facturas y envíos asociados a su<br>propia cuenta.|
|RN-10|Solo los administradores pueden crear, modificar o eliminar productos,<br>actualizar inventario, configurar planes y cambiar estados de envío.|
|RN-11|Los planes de suscripción disponibles serán mensual, semestral y anual, cada<br>uno con un precio definido por el administrador.|
|RN-12|El sistema debe conservar el historial de pre-facturas y pagos realizados<br>por cada usuario para consulta y control administrativo.|



## **1.5 Matriz de Trazabilidad de Requisitos** 

Relacionar los requisitos de usuario con los requisitos funcionales, requisitos no funcionales y reglas de negocio que permiten satisfacerlos. 

La matriz debe permitir verificar que las necesidades identificadas tengan cobertura dentro de la solución y detectar requisitos sin relación o sin justificación. El estado de cobertura puede clasificarse como: 

- **Completa:** la necesidad se encuentra adecuadamente cubierta. 

- **Parcial:** existen elementos pendientes por definir. 

- **Sin cobertura:** no se identifican requisitos del sistema que respondan a la necesidad. 

No es obligatorio asociar todos los RNF o reglas de negocio con un único requisito de usuario. Cuando una condición aplique a todo el sistema, debe indicarse como **Global** . 

|**Requisitos de**|**Requisitos**|**Requisitos No**|**Reglas**|**de**|**Estado**|**de**|
|---|---|---|---|---|---|---|
|**Usuario**|**Funcionales**|**Funcionales**|**Negocio**||**Cobertura**||
|RU-01|RF-01, FR-02|RNF-01|RN-01||Completa||
|RU-02|RF-03|RNF-02|RN-02||Completa||



|**Requisitos de Usuario**|**Requisitos**<br>**Funcionales**|**Requisitos**<br>**No**<br>**Funcionales**|**Reglas de**<br>**Negocio**|**Estado de**<br>**Cobertura**|
|---|---|---|---|---|
|**RU-01: Exploración de**<br>**catálogo y planes**<br>El usuario necesita<br>consultar las cajas<br>disponibles, buscar<br>opciones por temática,<br>revisar el contenido y<br>comparar los planes de<br>suscripción para tomar<br>una decisión.|RF-05,<br>RF-06,<br>RF-07,<br>RF-08, RF-09|RNF-03,<br>RNF-05,<br>RNF-08<br>_(Globales:_<br>_RNF-04,_<br>_RNF-07)_|RN-11|Completa|
|**RU-02: Registro y**<br>**personalización de**<br>**perfil**|RF-01,<br>RF-02,<br>RF-03, RF-04|RNF-01,<br>RNF-02,<br>RNF-03,<br>RNF-06|RN-01,<br>RN-05|Completa|
|El usuario necesita<br>crear una cuenta en la<br>plataforma y registrar<br>sus intereses para<br>garantizar que los<br>productos asignados a<br>su caja coincidan con<br>sus preferencias.||_(Globales:_<br>_RNF-04)_|||
|**RU-03: Gestión de**<br>**pre-facturación y**<br>**seguimiento logístico**|RF-10, RF-11,<br>RF-12, RF-13|RNF-01,<br>RNF-06,<br>RNF-10|RN-01,<br>RN-02,<br>RN-03,<br>RN-04,<br>RN-08,|Completa|
|El usuario necesita<br>validar el costo de su<br>suscripción mediante||_(Globales:_<br>_RNF-04)_|RN-09,<br>RN-12||



|una pre-factura,<br>confirmar el pago y<br>rastrear el estado de su<br>envío hasta recibirlo.|||||
|---|---|---|---|---|
|**RU-04: Operación de**<br>**inventario y logística**<br>El administrador<br>necesita garantizar la<br>revisión de<br>suscripciones activas,<br>actualizar el inventario,<br>asignar productos a las<br>cajas y gestionar el<br>estado de los<br>despachos.|RF-14,<br>RF-15,<br>RF-16, RF-18|RNF-01,<br>RNF-06,<br>RNF-09<br>_(Globales:_<br>_RNF-07)_|RN-05,<br>RN-06,<br>RN-07,<br>RN-08,<br>RN-10|Completa|
|**RU-05: Configuración**<br>**comercial y métricas**|RF-15,<br>RF-17,<br>RF-18, RF-19|RNF-01,<br>RNF-07,<br>RNF-09|RN-10,<br>RN-11,<br>RN-12|Completa|
|El administrador<br>necesita gestionar la<br>creación de cajas,<br>definir los precios de los<br>planes y consultar<br>estadísticas generales<br>para apoyar las<br>decisiones del negocio.||_(Globales:_<br>_RNF-04)_|||



## **2. Story Mapping** 



<!-- Start of picture text -->
STORY MAPPING - Plataforma de Suscripcion de Cajas<br>Actividades principales del usuario<br>4.Explorarcatilogo | { 2. Reoistoy per Aremyexs<br>@ RELEASE 1 — MVP (Producto Minimo Viable)<br>@ RELEASE 2 — Funcionalidades de mejora<br>@ RELEASE 3 — Funcionalidades avanzadas<br><!-- End of picture text -->

## **3. Historias de Usuario/Casos de Uso** 

En este apartado se debe definir claramente el enfoque elegido para la especificación funcional: Si se trabaja con Historias de Usuario (HU), deben estar correctamente estructuradas, completas y los criterios de aceptación en formato Gherkin. Usar herramienta ágil para su entrega. 

Si se trabaja con Casos de Uso, deben incluir diagrama UML (imagen y enlace) y descripción formal (plantilla). Usar la estructura de refinamiento en cualquiera (CU-HU) No se aceptan mezclas parciales ni descripciones informales o ambigüedades. 

Link a las historias de usuario: 

<u>Historias_usuario</u> 

## **4. Diagrama de clases** 

El diagrama de clases de diseño debe representar la estructura del sistema de manera clara y precisa. (imagen y enlace) 



<!-- Start of picture text -->
me ee _| [-—=—<br>a<br>— orale me<br>Con 1 [comsomeone<br>cinco *<br>a<br>="<br>we<br>sonore<br>Siac ve<br>ie ae ars fposmmememee<br>-OaenateSera arson ~oestensedueed-csca vis a |fe<br>eect tr awcwaen | |-aoue pee 1 ma<br>-+verSuseripciones: String 7 a String nombre<br>= i ant ce<br>“ _==—|<br>me<br>vlc oe | “Dateca ocnainico Le‘<br>paren ‘<br>cmarenovate [verte<br>of ae rereoaansemsde bon<br>String nombre ‘<br>sad,<br>a<br>ee |a<br>+‘decimaling Eade costoFinal String= Decaldescrpcionprecio SUOSLUSLOSCURET EneaBianEstadoEnvio<br><!-- End of picture text -->

<u>https://viewer.diagrams.net/?tags=%7B%7D&lightbox=1&highlight=0000ff&edit</u> =_blank&layers=1&nav=1&tit… 

## **5. Prototipo Figma** 

El prototipo en Figma debe de alta fidelidad donde se refleje las funcionalidades del sistema. (enlace) 



<!-- Start of picture text -->
Boxl Inicio (QUERSE —tienda = Perfil. = Ayuda Qn ea<br>oxly :<br>Bienvenido Jose!°<br>Inicio Mis suscripciones actuales<br>Mis cajas<br>Cuidado personal iv) Videojuegos iv] Implementos gym 9<br>r a | =<br><!-- End of picture text -->

## Link a figma: 

## <u>Figma</u> 

**El entregable debe incluir:** Documento PDF debe cumplir con todos los criterios mencionados, asegurando que el proyecto esté bien planificado y alineado con las expectativas de los stakeholders. 

