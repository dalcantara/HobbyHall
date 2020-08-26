#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY HobbyHall.Api/HobbyHall.Api.csproj HobbyHall.Api/
RUN dotnet restore "HobbyHall.Api/HobbyHall.Api.csproj"
COPY . .
WORKDIR "/src/HobbyHall.Api"
RUN dotnet build "HobbyHall.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HobbyHall.Api.csproj" -c Release -o /app/publish

FROM base AS final
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HobbyHall.Api.dll"]
