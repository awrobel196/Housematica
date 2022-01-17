#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Housematica.NewWWW/Housematica.NewWWW.csproj", "Housematica.NewWWW/"]
COPY ["Housematica.Data/Housematica.Data.csproj", "Housematica.Data/"]
RUN dotnet restore "Housematica.NewWWW/Housematica.NewWWW.csproj"
COPY . .
WORKDIR "/src/Housematica.NewWWW"
RUN dotnet build "Housematica.NewWWW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Housematica.NewWWW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Housematica.NewWWW.dll"]