# Dockerfile for ApiGateway
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app
COPY *.sln .
COPY ApiGateway/*.csproj ./ApiGateway/
RUN dotnet restore

COPY ApiGateway/. ./ApiGateway/
WORKDIR /app/ApiGateway
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/ApiGateway/out ./
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
