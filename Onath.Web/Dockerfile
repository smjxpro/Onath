FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Onath.Web/Onath.Web.csproj", "Onath.Web/"]
RUN dotnet restore "Onath.Web/Onath.Web.csproj"
COPY . .
WORKDIR "/src/Onath.Web"
RUN dotnet build "Onath.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onath.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onath.Web.dll"]
