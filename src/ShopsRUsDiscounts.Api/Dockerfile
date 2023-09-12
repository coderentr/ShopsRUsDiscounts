#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ShopsRUsDiscounts.Api/ShopsRUsDiscounts.Api.csproj", "src/ShopsRUsDiscounts.Api/"]
COPY ["src/ShopsRUsDiscounts.Infrastructure/ShopsRUsDiscounts.Infrastructure.csproj", "src/ShopsRUsDiscounts.Infrastructure/"]
COPY ["src/ShopsRUsDiscounts.Domain/ShopsRUsDiscounts.Domain.csproj", "src/ShopsRUsDiscounts.Domain/"]
COPY ["src/ShopsRUsDiscounts.Application/ShopsRUsDiscounts.Application.csproj", "src/ShopsRUsDiscounts.Application/"]
RUN dotnet restore "src/ShopsRUsDiscounts.Api/ShopsRUsDiscounts.Api.csproj"
COPY . .
WORKDIR "/src/src/ShopsRUsDiscounts.Api"
RUN dotnet build "ShopsRUsDiscounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopsRUsDiscounts.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopsRUsDiscounts.Api.dll"]
