#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RemoteConfig/Pretech.Software.RConfig.ApiServer/Pretech.Software.RConfig.ApiServer.csproj", "RemoteConfig/Pretech.Software.RConfig.ApiServer/"]
COPY ["RemoteConfig/Pretech.Software.RConfig.Core/Pretech.Software.RConfig.Core.csproj", "RemoteConfig/Pretech.Software.RConfig.Core/"]
COPY ["RemoteConfig/Pretech.Software.RConfig.Crypto/Pretech.Software.RConfig.Crypto.csproj", "RemoteConfig/Pretech.Software.RConfig.Crypto/"]
RUN dotnet restore "RemoteConfig/Pretech.Software.RConfig.ApiServer/Pretech.Software.RConfig.ApiServer.csproj"
COPY . .
WORKDIR "/src/RemoteConfig/Pretech.Software.RConfig.ApiServer"
RUN dotnet build "Pretech.Software.RConfig.ApiServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pretech.Software.RConfig.ApiServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf

ENTRYPOINT ["dotnet", "Pretech.Software.RConfig.ApiServer.dll"]