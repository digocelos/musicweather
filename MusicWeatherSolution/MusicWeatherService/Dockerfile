#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MusicWeatherService/MusicWeatherService.csproj", "MusicWeatherService/"]
RUN dotnet restore "MusicWeatherService/MusicWeatherService.csproj"
COPY . .
WORKDIR "/src/MusicWeatherService"
RUN dotnet build "MusicWeatherService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicWeatherService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicWeatherService.dll"]