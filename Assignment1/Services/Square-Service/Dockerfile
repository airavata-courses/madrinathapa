FROM microsoft/aspnetcore-build:1.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore

# Copy everything else and build
RUN dotnet build
RUN dotnet publish 

# Build runtime image
ENTRYPOINT ["dotnet", "run"]
