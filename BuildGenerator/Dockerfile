# Dockerfile for BuildGenerator
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app
COPY *.sln .
COPY src/Api/*.csproj ./src/Api/
COPY src/Bll/*.csproj ./src/Bll/
COPY src/Dal/*.csproj ./src/Dal/
RUN dotnet restore

COPY src/ ./
WORKDIR /app/src/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/src/Api/out ./
ENTRYPOINT ["dotnet", "Api.dll"]
