FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["../CarseerAssignment.Web/CarseerAssignment.Web.csproj", "CarseerAssignment.Web/"]
COPY ["../CarseerAssignment.Infrastructure/CarseerAssignment.Infrastructure.csproj", "CarseerAssignment.Infrastructure/"]
COPY ["../CarseerAssignment.Application/CarseerAssignment.Application.csproj", "CarseerAssignment.Application/"]

RUN dotnet restore "CarseerAssignment.Web/CarseerAssignment.Web.csproj"

COPY ../ .

WORKDIR "/src/CarseerAssignment.Web"
RUN dotnet build "CarseerAssignment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CarseerAssignment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarseerAssignment.Web.dll"]
