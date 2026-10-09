# Orion - Programa de Reconocimientos

## 1. Descripción del Proyecto
**Orion** es una aplicación web empresarial diseñada para la gestión integral del Programa de Reconocimientos de la institución (por ejemplo, nominación de colaboradores destacados). A través de la plataforma, los directivos y el personal pueden postular a empleados que demuestran un trabajo excepcional y contribuyen a la cultura organizacional, recibiendo el distintivo de "Estrellas".

La aplicación incluye un sistema de notificación automática mediante correo electrónico, integrado con su servicio backend para gestionar las nominaciones.

---

## 2. Pila Tecnológica (Tech Stack)

La aplicación es un proyecto desarrollado principalmente bajo el ecosistema de tecnologías web de Microsoft, estructurado de la siguiente forma:

**Backend / Core:**
- **Lenguaje:** Visual Basic .NET (VB.NET)
- **Framework:** .NET Framework 4.5.2
- **Arquitectura Web:** ASP.NET Web Forms
- **Servicios:** Consume un servicio WCF externo (Windows Communication Foundation), referenciado localmente como `wsOrion.svc`.

**Frontend:**
- **Frameworks UI:** Bootstrap 3.0.0
- **JavaScript/Librerías:** jQuery 1.10.2, Modernizr 2.6.2
- **Diseño Responsivo:** Soporte básico a través de Bootstrap.

**Dependencias Principales (Gestión de Paquetes vía NuGet):**
- **Newtonsoft.Json 6.0.4**: Para la serialización y deserialización de datos JSON.
- **Microsoft.AspNet.Web.Optimization**: Sistema de empaquetado (Bundling) y minificación web (usando WebGrease y Antlr).
- Librerías propias contenidas en `App_Code/` (e.g., `AppGeneral.dll`, `AppMail.dll`, `SQLDataAccess.dll`, `wsOrionProxy.dll`).

---

## 3. Instalación Local y Configuración del Entorno

Sigue estos pasos para compilar y ejecutar el proyecto desde cero en tu entorno de desarrollo.

### Requisitos Previos:
- [Visual Studio](https://visualstudio.microsoft.com/) (2015, 2017, 2019 o superior) con la carga de trabajo "**Desarrollo de ASP.NET y web**" instalada.
- SDK de **.NET Framework 4.5.2**.
- Acceso o un mock local del servicio WCF de Orion (`IwsOrion`), ya que la aplicación web es en parte un cliente que depende de éste.

### Pasos de Instalación:

1. **Clonar el repositorio**
   ```bash
   git clone <url-del-repositorio>
   cd <nombre-del-repositorio>
   ```

2. **Abrir la Solución**
   - Abre el archivo `Orion.sln` con Visual Studio.

3. **Restaurar Paquetes NuGet**
   - Haz clic derecho sobre la solución en el *Explorador de Soluciones* (Solution Explorer) y selecciona **Restaurar paquetes NuGet**. Esto descargará dependencias como Bootstrap, jQuery, WebGrease, entre otras.

4. **Configurar Variables de Entorno (`Web.config`)**
   - Abre el archivo `Orion/Web.config` situado en la raíz del proyecto web.
   - **Endpoint WCF**: Busca la etiqueta `<client>` en `<system.serviceModel>`. Deberás cambiar el atributo `address` para apuntar a la URL válida de tu servicio WCF local o de desarrollo.
     ```xml
     <endpoint address="http://localhost:0000/wsOrion.svc" binding="basicHttpBinding" bindingConfiguration="MainBnd" contract="IwsOrion" name="Basic"/>
     ```
   - **AppSettings**: Revisa y actualiza las claves dentro de `<appSettings>`, tales como:
     - `app_global_imagenes`: Ruta de red donde se almacenan las fotos (ej. `\\1.1.1.1\FOTOS\`).
     - `app_email_cc`: Dirección de correo electrónico genérica de copia.

5. **Compilar y Ejecutar**
   - Selecciona la configuración `Debug` o `Release`.
   - Compila la solución (`Ctrl + Shift + B`).
   - Ejecuta la aplicación mediante IIS Express (`F5`). Por defecto, intentará correr en `http://localhost:60251/`.

---

## 4. Estructura Principal de Carpetas

A continuación, se detalla la estructura principal del proyecto web `Orion`:

```
Orion/
├── App_Code/      # Librerías DLL y utilidades propias (acceso a datos, envío de correos, utilitarios matemáticos y el proxy del servicio WCF).
├── App_Start/     # Configuración inicial de la aplicación, como empaquetado de archivos web (BundleConfig.vb) y enrutamiento amigable (RouteConfig.vb).
├── Content/       # Hojas de estilo CSS principales de la aplicación y la librería de Bootstrap.
├── fonts/         # Fuentes tipográficas web (por ej. Glyphicons para Bootstrap).
├── Images/        # Archivos de imagen estáticos, logos del sistema y recursos visuales.
├── Pages/         # Formularios web (.aspx) principales de la aplicación: Califica, Reportes, entre otros.
├── Scripts/       # Archivos de JavaScript, incluyendo jQuery, librerías de validación WebForms propias de Microsoft (MSAjax) y Modernizr.
├── Web.config     # Archivo central de configuración de ASP.NET, donde se establecen variables de entorno, ajustes del runtime y endpoints.
└── Default.aspx   # Página principal/dashboard tras el inicio de sesión.
```

---

## 5. Guía de Uso / Ejemplos

Dado que se trata de un cliente web administrado a través de **IIS**, las interacciones se realizan mayoritariamente a través del navegador web.

- **Levantamiento Básico**: Una vez ejecutado con `F5` en Visual Studio, el sistema levantará una instancia en IIS Express. Navega hacia la URL asignada.
- **Inicio de Sesión**: La autenticación depende de las configuraciones y validaciones provistas en el `Default.aspx` en conjunto con la comunicación hacia el servicio WCF.
- **Páginas Destacadas**:
  - Puedes realizar pruebas de calificación o nominación navegando a `http://localhost:PUERTO/Pages/Califica.aspx`.
  - Los reportes del programa se pueden revisar desde `http://localhost:PUERTO/Pages/Reporte.aspx`.
- **Atajos**: Si experimentas problemas de inicio de sesión o validación en tiempo de desarrollo, cerciórate en el `Web.config` que las llamadas a los servicios (`wsOrionProxy.dll`) estén apuntando a los servidores correctos o utiliza un mock en caso de no disponer del servidor WCF.
