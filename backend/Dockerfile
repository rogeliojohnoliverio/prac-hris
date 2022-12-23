FROM mcr.microsoft.com/dotnet/sdk:6.0 AS watch
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
COPY . .
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5163"]
