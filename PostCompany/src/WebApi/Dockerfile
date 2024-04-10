#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["src/Config/Config.csproj", "src/Config/"]
COPY ["src/PresentationFacade/PresentationFacade.csproj", "src/PresentationFacade/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["common/Common.Application/Common.Application.csproj", "common/Common.Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["common/Common.Domain/Common.Domain.csproj", "common/Common.Domain/"]
COPY ["src/Query/Query.csproj", "src/Query/"]
COPY ["common/Common.Query/Common.Query.csproj", "common/Common.Query/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "./src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]