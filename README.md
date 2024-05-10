# Backend Buscador de Acciones

> [.NET](https://dotnet.microsoft.com/es-es/)

## Descripción
API construida con .NET versión 8.0 y Microsoft.EntityFrameworkCore versión 8.0.4, Microsoft.EntityFrameworkCore.Design, Npgsql.EntityFrameworkCore.PostgreSQL. Con string de conexión para usar con PostgreSQL 14. 

## Instalación
Sigue los pasos a continuación para instalar el proyecto:

1. Posicionado en el directorio que desee clone el repositorio con: 

```bash
git clone https://github.com/lucasfrontend/realtime-stock-grapher-back.git
```
2. Navegue hasta posicionarse en el directorio del proyecto: 

```bash
cd realtime-stock-grapher-back.git
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

Tendrá disponible el proyecto en [localhost:5144/](http://localhost:5144/).
Si tiene el frontend configurado podrá visualizarlo el frontend en [http://localhost:3000/](http://localhost:3000/). 
Asegúrese de que dichos puertos no estén siendo utilizados por otros procesos.
