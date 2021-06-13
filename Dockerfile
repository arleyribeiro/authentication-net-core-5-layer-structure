FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Authentication/*.csproj ./Authentication/

COPY Core/*.csproj ./Core/
COPY Core.Interfaces/*.csproj ./Core.Interfaces/
COPY Core.IoC/*.csproj ./Core.IoC/

COPY Domain/*.csproj ./Domain/

COPY Infrastructure/*.csproj ./Infrastructure/
COPY Infrastructure.Interfaces/*.csproj ./Infrastructure.Interfaces/
COPY Infrastructure.IoC/*.csproj ./Infrastructure.IoC/

COPY Tests/*.csproj ./Tests/

RUN dotnet restore

# copy everything else and build app
COPY Authentication/. ./Authentication/

COPY Core/. ./Core/
COPY Core.Interfaces/. ./Core.Interfaces/
COPY Core.IoC/. ./Core.IoC/

COPY Domain/. ./Domain/

COPY Infrastructure/. ./Infrastructure/
COPY Infrastructure.Interfaces/. ./Infrastructure.Interfaces/
COPY Infrastructure.IoC/. ./Infrastructure.IoC/

COPY Tests/. ./Tests/

WORKDIR /app/Authentication
RUN dotnet publish -c debug -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet AS runtime
WORKDIR /app
COPY --from=build /app/Authentication/out ./
# Container ASP.NET
#ENTRYPOINT ["dotnet", "Authentication.dll"]

# Usage to Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Authentication.dll
