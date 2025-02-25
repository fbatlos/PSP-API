# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY GameScoresAPI.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto en el que la aplicación escuchará
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "GameScoresAPI.dll"]
