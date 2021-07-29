FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY *.sln .
COPY dr.TeslaApiFacade/dr.TeslaApiFacade.csproj ./dr.TeslaApiFacade/dr.TeslaApiFacade.csproj
COPY dr.TeslaApiFacade.Tests/dr.TeslaApiFacade.Tests.csproj ./dr.TeslaApiFacade.Tests/dr.TeslaApiFacade.Tests.csproj
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /src/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /src/out .
CMD ["dotnet", "dr.TeslaApiFacade.dll"]