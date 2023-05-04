FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy and restore project files
COPY *.sln .
COPY src/Api/*.csproj ./src/Api/
COPY src/Bll/*.csproj ./src/Bll/
COPY src/Dal/*.csproj ./src/Dal/
RUN dotnet restore

# Copy the source code and build the application
COPY src/ ./src/
WORKDIR /app/src/Api
RUN dotnet publish -c Release -o out -restore

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/src/Api/out ./

# Set the entry point to your app's DLL
ENTRYPOINT ["dotnet", "Api.dll"]
