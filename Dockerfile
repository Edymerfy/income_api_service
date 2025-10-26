FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore ./Services.Tax.Api/Services.Tax.Api.csproj
RUN dotnet publish ./Services.Tax.Api/Services.Tax.Api.csproj -c Release -o /publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Services.Tax.Api.dll"]
