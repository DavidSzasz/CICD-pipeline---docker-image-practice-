FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy everything and restore using the exact solution name
COPY . .
RUN dotnet restore "CICD-pipeline---docker-image-practice-.sln"

# Publish the Presentation project
WORKDIR /src/Presantation
RUN dotnet publish "Presantation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Copy your generated dependency report into the container
COPY dependencies.json /app/dependencies.json

ENTRYPOINT ["dotnet", "Presantation.dll"]