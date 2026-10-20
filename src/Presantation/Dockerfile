FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore "src/CICD-pipeline---docker-image-practice-.slnx"

WORKDIR /app/src/Presantation
RUN dotnet publish "Presantation.csproj" -c Release -o /out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /out .
COPY dependencies.json /app/dependencies.json

ENTRYPOINT ["dotnet", "Presantation.dll"]