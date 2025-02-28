# Utiliza una imagen base de .NET SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos y publica la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Utiliza una imagen base de .NET runtime para ejecutar la aplicación
# Usa la imagen base de .NET 9 para ejecutar la aplicación (si tu proyecto requiere .NET 9)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "GameScoresAPI.dll"]

