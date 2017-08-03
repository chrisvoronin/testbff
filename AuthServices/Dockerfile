FROM microsoft/dotnet:1.1-sdk-msbuild



WORKDIR /app

# COPY *.csproj .

COPY . .

RUN dotnet clean
RUN dotnet restore


RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/AuthServices.dll", "--server.urls", "http://0.0.0.0:5000"]