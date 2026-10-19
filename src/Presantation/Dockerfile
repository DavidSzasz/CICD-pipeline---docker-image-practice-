FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy the whole repository and restore using the path inside src/
COPY . .
RUN dotnet restore "src/CICD-pipeline---docker-image-practice-.sln"

# Publish the Presantation project from the src folder
WORKDIR /app/src/Presantation
RUN dotnet publish "Presantation.csproj" -c Release -o /out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /out .

# Copy your generated dependency report into the container
COPY dependencies.json /app/dependencies.json

ENTRYPOINT ["dotnet", "Presantation.dll"]