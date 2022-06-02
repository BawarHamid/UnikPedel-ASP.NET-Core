#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnikPedel.ApiInterface/UnikPedel.ApiInterface.csproj", "UnikPedel.ApiInterface/"]
COPY ["UnikPedel.Infrastructure/UnikPedel.Infrastructure.csproj", "UnikPedel.Infrastructure/"]
COPY ["UnikPedel.Application/UnikPedel.Application.csproj", "UnikPedel.Application/"]
COPY ["UnikPedel.Domain/UnikPedel.Domain.csproj", "UnikPedel.Domain/"]
COPY ["UnikPedel.Web/UnikPedel.Web.csproj", "UnikPedel.Web/"]
COPY ["UnikPedel.Contract/UnikPedel.Contract.csproj", "UnikPedel.Contract/"]
RUN dotnet restore "UnikPedel.ApiInterface/UnikPedel.ApiInterface.csproj"
COPY . .
WORKDIR "/src/UnikPedel.ApiInterface"
RUN dotnet build "UnikPedel.ApiInterface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnikPedel.ApiInterface.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnikPedel.ApiInterface.dll"]