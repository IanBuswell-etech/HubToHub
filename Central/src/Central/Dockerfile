FROM microsoft/dotnet:sdk as builder
WORKDIR /source

COPY ./Central.Api/*.csproj ./Central.Api/
WORKDIR /source/Central.Api
RUN dotnet restore

WORKDIR /source
COPY . .

WORKDIR /source/Central.Api
RUN dotnet publish --output /app/ --configuration Release

FROM microsoft/aspnetcore:2.0.0
WORKDIR /app

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Central.Api.dll"]