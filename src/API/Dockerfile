#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src
COPY ["src/API/API.csproj", "API/"]
COPY ["src/API.Tests/API.Tests.csproj", "API.Tests/"]
COPY ["src/DataFacade/DataFacade.csproj", "DataFacade/"]
COPY ["src/DataFacade.Tests/DataFacade.Tests.csproj", "DataFacade.Tests/"]
RUN dotnet restore "API/API.csproj"
COPY src/. .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

#FROM build AS test
WORKDIR "/src"
RUN dotnet test API.Tests -c Release
RUN dotnet test DataFacade.Tests

FROM build AS publish
WORKDIR "/src/API"
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
