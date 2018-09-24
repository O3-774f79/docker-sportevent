FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SportEvent/SportEvent.csproj SportEvent/
COPY SportEvent.Helper/SportEvent.Helper.csproj SportEvent.Helper/
COPY SportEvent.Bll/SportEvent.Bll.csproj SportEvent.Bll/
COPY SportEvent.Data/SportEvent.Data.csproj SportEvent.Data/
RUN dotnet restore SportEvent/SportEvent.csproj
COPY . .
WORKDIR /src/SportEvent
RUN dotnet build SportEvent.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SportEvent.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SportEvent.dll"]
