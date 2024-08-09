#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebAppCookBook.Frontend/WebAppCookBook.Frontend.csproj", "WebAppCookBook.Frontend/"]
COPY ["WebAppCookBook.API/WebAppCookBook.API.csproj", "WebAppCookBook.API/"]
RUN dotnet restore "./WebAppCookBook.Frontend/WebAppCookBook.Frontend.csproj"
COPY . .
WORKDIR "/src/WebAppCookBook.Frontend"
RUN dotnet build "./WebAppCookBook.Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAppCookBook.Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppCookBook.Frontend.dll"]