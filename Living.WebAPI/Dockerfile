FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "Living.WebAPI/Living.WebAPI.csproj"

WORKDIR "/src/Living.WebAPI"

RUN dotnet build "Living.WebAPI.csproj" -c Release -o /app/build

RUN dotnet publish "Living.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Living.WebAPI.dll"]