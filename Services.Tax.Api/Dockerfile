FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services.Tax.Api/Services.Tax.Api.csproj", "Services.Tax.Api/"]
COPY ["Services.Tax.Domain/Services.Tax.Domain.csproj", "Services.Tax.Domain/"]
COPY ["Services.Tax.Infrastructure/Services.Tax.Infrastructure.csproj", "Services.Tax.Infrastructure/"]
RUN dotnet restore "./Services.Tax.Api/Services.Tax.Api.csproj"
COPY . .
WORKDIR "/src/Services.Tax.Api"
RUN dotnet build "./Services.Tax.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Services.Tax.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.Tax.Api.dll"]