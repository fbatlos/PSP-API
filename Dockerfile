# Utiliza una imagen base de .NET SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos y publica la aplicación
COPY . 
RUN dotnet publish -c Release -o out

# Utiliza una imagen base de .NET runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expone el puerto en el que la aplicación escuchará
EXPOSE 80

# Define el punto de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "GameScoresAPI.dll"]
