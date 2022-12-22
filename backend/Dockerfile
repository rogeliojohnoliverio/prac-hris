FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS http://*:5163
EXPOSE 5163

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet dev-certs https
WORKDIR /src
COPY ["backend.csproj", "."]
RUN dotnet restore "backend.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "watch", "run", "--no-restore"]
