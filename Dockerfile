FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
LABEL vendor="p3-software & line-of-code"
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY src .
RUN dotnet restore
COPY . .
WORKDIR "/src/Saiive.Alert"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

EXPOSE 5000
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saiive.Alert.dll"]