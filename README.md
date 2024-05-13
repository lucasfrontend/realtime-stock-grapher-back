# Backend Buscador de Acciones

> [.NET](https://dotnet.microsoft.com/es-es/)

## Descripción
API construida con .NET versión 8.0 y Microsoft.EntityFrameworkCore versión 8.0.4, Microsoft.EntityFrameworkCore.Design, Npgsql.EntityFrameworkCore.PostgreSQL. String de conexión para usar con PostgreSQL 14 y backup "database.sql". 

## Instalación
Sigue los pasos a continuación para instalar el proyecto:

1. Posicionado en el directorio que desee clone el repositorio con: 

```bash
git clone https://github.com/lucasfrontend/realtime-stock-grapher-back
```
2. Navegue hasta posicionarse en el directorio del proyecto: 

```bash
cd realtime-stock-grapher-back/ACCIONES-BACKEND
```
3. Descargue los paquetes NuGet
```bash
dotnet restore
```

4. Puede compilar el proyecto con:
```bash
dotnet build
```

5. Corra el siguiente comando para ejecutar localmente el proyecto:
```bash
dotnet run
```

Verifique la conectividad y que el proyecto haya sido levantado correctamente navegando a [http://localhost:5144/api/users/test](http://localhost:5144/api/users/test), donde encontrará además las credenciales para el inicio de sesión. Ej: username:	"metafar", password: "metafar"

Si tiene el frontend configurado podrá visualizarlo en [http://localhost:3000/](http://localhost:3000/). 
Asegúrese de que dichos puertos no estén siendo utilizados por otros procesos.


