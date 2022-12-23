FROM mcr.microsoft.com/dotnet/sdk:6.0 AS watch
WORKDIR /src
COPY ./backend .
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5163"]
