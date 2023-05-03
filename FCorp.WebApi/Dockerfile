#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FCorp.WebApi/FCorp.WebApi.csproj", "FCorp.WebApi/"]
COPY ["FCopr.Application/FCopr.Application.csproj", "FCopr.Application/"]
COPY ["FCorp.Domain/FCorp.Domain.csproj", "FCorp.Domain/"]
COPY ["FCorp.Persistence/FCorp.Persistence.csproj", "FCorp.Persistence/"]
RUN dotnet restore "FCorp.WebApi/FCorp.WebApi.csproj"
COPY . .
WORKDIR "/src/FCorp.WebApi"
RUN dotnet build "FCorp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCorp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCorp.WebApi.dll"]