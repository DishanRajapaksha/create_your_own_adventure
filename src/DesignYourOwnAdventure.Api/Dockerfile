FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DesignYourOwnAdventure.Api/DesignYourOwnAdventure.Api.csproj", "DesignYourOwnAdventure.Api/"]
COPY ["DesignYourOwnAdventure.Core/DesignYourOwnAdventure.Core.csproj", "DesignYourOwnAdventure.Core/"]
COPY ["DesignYourOwnAdventure.Infrastructure/DesignYourOwnAdventure.Infrastructure.csproj", "DesignYourOwnAdventure.Infrastructure/"]
RUN dotnet restore "DesignYourOwnAdventure.Api/DesignYourOwnAdventure.Api.csproj"
COPY . .
WORKDIR "/src/DesignYourOwnAdventure.Api"
RUN dotnet build "DesignYourOwnAdventure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesignYourOwnAdventure.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignYourOwnAdventure.Api.dll"]