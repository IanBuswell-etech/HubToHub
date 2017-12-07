FROM microsoft/dotnet:sdk as builder
WORKDIR /source

COPY ./MiniHub.Api/*.csproj ./MiniHub.Api/
COPY ./MiniHub.Services/*.csproj ./MiniHub.Services/
COPY ./MiniHub.Data/*.csproj ./MiniHub.Data/
COPY ./MiniHub.Data.LiteDb/*.csproj ./MiniHub.Lite.Db/
WORKDIR /source/MiniHub.Api
RUN dotnet restore

WORKDIR /source
COPY . .

WORKDIR /source/MiniHub.Api
RUN dotnet publish --output /app/ --configuration Release

FROM microsoft/dotnet:2.0.0-runtime
WORKDIR /app

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "MiniHub.Api.dll"]