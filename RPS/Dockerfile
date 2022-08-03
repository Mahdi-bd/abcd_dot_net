#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RPS/RPS.csproj", "RPS/"]
RUN dotnet restore "RPS/RPS.csproj"

COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "Entities\Entities.csproj"

COPY ["Services.Abstractions/Services.Abstractions.csproj", "Services.Abstractions/"]
RUN dotnet restore "Services.Abstractions\Services.Abstractions.csproj"
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "Services\Services.csproj"

COPY ["Repository.Contracts/Repository.Contracts.csproj", "Repository.Contracts/"]
RUN dotnet restore "Repository.Contracts\Repository.Contracts.csproj"
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "Repository\Repository.csproj"

COPY . .
WORKDIR "/src/RPS"
RUN dotnet build "RPS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RPS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPS.dll"]