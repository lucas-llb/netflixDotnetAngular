
# Building dotnet app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copying files and restore packages
COPY netflixProjectBackendDotNet.Api/netflixProjectBackendDotNet.Api.csproj netflixProjectBackendDotNet.Api/
COPY netflixProjectBackendDotNet.Domain/netflixProjectBackendDotNet.Domain.csproj netflixProjectBackendDotNet.Domain/
COPY netflixProjectBackendDotNet.Infra/netflixProjectBackendDotNet.Infra.csproj netflixProjectBackendDotNet.Infra/
COPY netflixProjectBackendDotNet.IoC/netflixProjectBackendDotNet.IoC.csproj netflixProjectBackendDotNet.IoC/
COPY *.sln .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app

# Run application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5002
COPY --from=build /app .
ENV ASPNETCORE_ENVIRONMENT=Development 
ENV ASPNETCORE_URLS=http://*:5002
ENTRYPOINT ["dotnet", "netflixProjectBackendDotNet.Api.dll"]
