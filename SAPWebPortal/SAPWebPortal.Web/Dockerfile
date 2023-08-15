#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Serenity/NuGet.config", "Serenity/"]
COPY ["SAPWebPortal/SAPWebPortal.Web/SAPWebPortal.Web.csproj", "SAPWebPortal/SAPWebPortal.Web/"]
COPY ["Serenity/src/Serenity.Net.Web/Serenity.Net.Web.csproj", "Serenity/src/Serenity.Net.Web/"]
COPY ["Serenity/src/Serenity.Net.Services/Serenity.Net.Services.csproj", "Serenity/src/Serenity.Net.Services/"]
COPY ["Serenity/src/Serenity.Net.Entity/Serenity.Net.Entity.csproj", "Serenity/src/Serenity.Net.Entity/"]
COPY ["Serenity/src/Serenity.Net.Core/Serenity.Net.Core.csproj", "Serenity/src/Serenity.Net.Core/"]
COPY ["Serenity/src/Serenity.Net.Data/Serenity.Net.Data.csproj", "Serenity/src/Serenity.Net.Data/"]
RUN dotnet restore "SAPWebPortal/SAPWebPortal.Web/SAPWebPortal.Web.csproj"
COPY . .
WORKDIR "/src/SAPWebPortal/SAPWebPortal.Web"
RUN dotnet build "SAPWebPortal.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SAPWebPortal.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAPWebPortal.Web.dll"]