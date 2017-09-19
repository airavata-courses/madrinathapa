FROM microsoft/aspnetcore-build:1.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:1.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://+:58912
EXPOSE 58912 3099 5000 8000 4099

ENTRYPOINT ["dotnet", "SgaApi.dll"]