FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY sigur-emulation.csproj .
RUN dotnet restore sigur-emulation.csproj

COPY . .
RUN dotnet publish sigur-emulation.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "sigur-emulation.dll"]