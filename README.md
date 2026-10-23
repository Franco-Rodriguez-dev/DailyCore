# DailyCore

DailyCore es una plataforma SaaS orientada a pequeños negocios y PyMEs para centralizar la gestión cotidiana de ingresos, gastos y movimientos.

## Estado del proyecto

Proyecto en desarrollo.

Actualmente se está trabajando en la primera versión del MVP.

## Tecnologías principales

- .NET 10
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Angular
- TypeScript
- JWT
- xUnit

## Arquitectura

El backend está organizado en los siguientes proyectos:

- DailyCore.Api
- DailyCore.Application
- DailyCore.Domain
- DailyCore.Infrastructure
## Ejecutar el backend en desarrollo

Requisitos: SDK de .NET 10 y una instancia de SQL Server en ejecución. El ejemplo usa SQL Server Express en Windows con autenticación de Windows; adaptá el servidor a tu instalación.

Desde la raíz del repositorio:

```powershell
dotnet restore backend/DailyCore.slnx
dotnet tool restore
```

Creá `backend/DailyCore.Api/appsettings.Development.json` con esta configuración local:

```json
{
  "ConnectionStrings": {
    "DailyCore": "Server=localhost\\SQLEXPRESS;Database=DailyCore;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

Este archivo está ignorado por Git. La clave `ConnectionStrings:DailyCore` es obligatoria para iniciar la API. El ejemplo no contiene contraseñas; `TrustServerCertificate=True` es para el entorno local de desarrollo. También se puede proporcionar la conexión mediante la variable de entorno `ConnectionStrings__DailyCore`.

Con SQL Server iniciado y un usuario con permisos para crear la base, aplicá la migración existente:

```powershell
dotnet ef database update --project backend/DailyCore.Infrastructure --startup-project backend/DailyCore.Api -- --environment Development
```

Este comando crea o actualiza la base configurada; no hace falta generar otra migración para ejecutar el proyecto.

Prepará el certificado HTTPS de desarrollo y ejecutá la API:

```powershell
dotnet dev-certs https --trust
dotnet run --project backend/DailyCore.Api --launch-profile https
```

Abrí https://localhost:7182/swagger en el navegador. Desde Visual Studio, abrí `backend/DailyCore.slnx`, seleccioná `DailyCore.Api` como proyecto de inicio y el perfil `https`. Swagger y el documento `/openapi/v1.json` se habilitan solo en Development.

Para probar `POST /api/empresas`, enviá:

```json
{
  "nombre": "  Almacén de prueba  "
}
```

Una solicitud válida inserta una empresa y devuelve 201 con `id`, `nombre` y `createdAt`. Un nombre con solo espacios o más de 100 caracteres después de quitar espacios exteriores devuelve 400. Cada ejecución válida crea un registro nuevo.

## Compilación y pruebas

Desde la raíz:

```powershell
dotnet build backend/DailyCore.slnx
dotnet test backend/DailyCore.Domain.Tests/DailyCore.Domain.Tests.csproj
```

Las pruebas de dominio no necesitan SQL Server. Las pruebas HTTP del registro sí requieren la API y la base configuradas.
