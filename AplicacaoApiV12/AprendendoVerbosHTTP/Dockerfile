FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY AprendendoVerbosHTTP/AprendendoVerbosHTTP.csproj AprendendoVerbosHTTP/
RUN dotnet restore AprendendoVerbosHTTP/AprendendoVerbosHTTP.csproj
COPY . .
WORKDIR /src/AprendendoVerbosHTTP
RUN dotnet build AprendendoVerbosHTTP.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AprendendoVerbosHTTP.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AprendendoVerbosHTTP.dll"]
