# Usa una imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar archivo .csproj y restaurar dependencias
COPY GameScoresAPI.csproj ./
RUN dotnet restore GameScoresAPI.csproj

# Copiar el resto de los archivos y compilar la aplicación
COPY . ./
RUN dotnet publish GameScoresAPI.csproj -c Release -o out --no-restore

# Usar la imagen base de .NET runtime 8.0 para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto en el que se ejecutará la aplicación
EXPOSE 80

# Configurar el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "GameScoresAPI.dll"]
