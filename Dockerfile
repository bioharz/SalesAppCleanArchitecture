FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
#COPY *.csproj .
COPY src/Application/Application.csproj src/Application/Application.csproj
COPY src/Domain/Domain.csproj  src/Domain/Domain.csproj 
COPY src/Infrastructure/Infrastructure.csproj src/Infrastructure/Infrastructure.csproj 
COPY src/WebUI/WebUI.csproj src/WebUI/WebUI.csproj 
COPY  tests/Application.UnitTests/Application.UnitTests.csproj  tests/Application.UnitTests/Application.UnitTests.csproj
COPY tests/Domain.UnitTests/Domain.UnitTests.csproj tests/Domain.UnitTests/Domain.UnitTests.csproj
COPY tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj
COPY tests/WebUI.IntegrationTests/WebUI.IntegrationTests.csproj tests/WebUI.IntegrationTests/WebUI.IntegrationTests.csproj
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
#BEGIN OF DIRTY WORKAROUND!
RUN apt-get update
RUN apt-get install --yes curl
RUN curl --silent --location https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install --yes nodejs
#END OF DIRTY WORKAROUND!
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app
RUN dotnet publish -c Release -o out CleanArchitecture.sln

LABEL vendor="Reza Shokri"

#building the main image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
#RUN adduser --disabled-password --gecos "" app
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV COMPlus_EnableDiagnostics=0
ENV ASPNETCORE_URLS="http://*:14000"
WORKDIR /app
COPY --from=build /app/out ./
#USER app
EXPOSE 14000
ENTRYPOINT ["dotnet", "CleanArchitecture.WebUI.dll"] 