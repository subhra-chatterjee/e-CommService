FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5071


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


COPY ["OrderService/OrderService.csproj", "OrderService/"]
COPY ["CartService/CartService.csproj", "CartService/"]


RUN dotnet restore "OrderService/OrderService.csproj"


COPY . .


RUN rm -f CartService/appsettings.json CartService/appsettings.Development.json


WORKDIR /src/OrderService
RUN dotnet build "OrderService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrderService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5071
ENTRYPOINT ["dotnet", "OrderService.dll"]
