FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["EventCatalogAPI.csproj", "./"]
RUN dotnet restore "EventCatalogAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "EventCatalogAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventCatalogAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventCatalogAPI.dll"]

#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /app
#EXPOSE 80
#
#COPY . .
#RUN dotnet restore ProductCatalogAPI.csproj
#
#FROM build AS publish
#RUN dotnet publish "ProductCatalogAPI.csproj" -c Release -o /app
#
#WORKDIR /app
#COPY --from=build /app .
#ENTRYPOINT ["dotnet", "ProductCatalogAPI.dll"]
#