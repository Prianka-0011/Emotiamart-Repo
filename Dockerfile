FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update
RUN apt-get update && \
    apt-get install -y nodejs npm
WORKDIR /emotia-mart
COPY . .     
RUN dotnet restore ./src/EmotiaMart.Backend/EmotiaMart.API/EmotiaMart.API.csproj

WORKDIR ./src/Web-Spa
RUN npm install
RUN npm run build

WORKDIR /emotia-mart
RUN dotnet build ./src/EmotiaMart.Backend/EmotiaMart.API/EmotiaMart.API.csproj -c Debug 
EXPOSE 2029
ENTRYPOINT ["dotnet", "watch", "--project", "src/EmotiaMart.Backend/EmotiaMart.API/EmotiaMart.API.csproj", "run", "--urls=https://0.0.0.0:2029"]