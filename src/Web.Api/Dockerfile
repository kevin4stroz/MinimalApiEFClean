#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Web.Api/Web.Api.csproj", "src/Web.Api/"]
COPY ["Web.Application.Dto/Web.Application.Dto.csproj", "Web.Application.Dto/"]
COPY ["Web.Application.Implementation/Web.Application.Implementation.csproj", "Web.Application.Implementation/"]
COPY ["Web.Application.Interfaces/Web.Application.Interfaces.csproj", "Web.Application.Interfaces/"]
COPY ["Web.Domain.Interfaces/Web.Domain.Interfaces.csproj", "Web.Domain.Interfaces/"]
COPY ["Web.Domain.Implementation/Web.Domain.Implementation.csproj", "Web.Domain.Implementation/"]
COPY ["Web.Infraestructure.Interfaces/Web.Infraestructure.Interfaces.csproj", "Web.Infraestructure.Interfaces/"]
COPY ["Web.Domain.Entities/Web.Domain.Entities.csproj", "Web.Domain.Entities/"]
COPY ["Web.Infraestructure.Implementation/Web.Infraestructure.Implementation.csproj", "Web.Infraestructure.Implementation/"]
RUN dotnet restore "./src/Web.Api/Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Web.Api"
RUN dotnet build "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.dll"]