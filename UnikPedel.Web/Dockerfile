#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnikPedel.Web/UnikPedel.Web.csproj", "UnikPedel.Web/"]
COPY ["UnikPedel.Contract/UnikPedel.Contract.csproj", "UnikPedel.Contract/"]
COPY ["UnikPedel.Infrastructure/UnikPedel.Infrastructure.csproj", "UnikPedel.Infrastructure/"]
COPY ["UnikPedel.Application/UnikPedel.Application.csproj", "UnikPedel.Application/"]
COPY ["UnikPedel.Domain/UnikPedel.Domain.csproj", "UnikPedel.Domain/"]
RUN dotnet restore "UnikPedel.Web/UnikPedel.Web.csproj"
COPY . .
WORKDIR "/src/UnikPedel.Web"
RUN dotnet build "UnikPedel.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnikPedel.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnikPedel.Web.dll"]