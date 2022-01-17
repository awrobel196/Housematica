#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Housematica.Intranet/Housematica.Intranet.csproj", "Housematica.Intranet/"]
COPY ["Housematica.Data/Housematica.Data.csproj", "Housematica.Data/"]
RUN dotnet restore "Housematica.Intranet/Housematica.Intranet.csproj"
COPY . .
WORKDIR "/src/Housematica.Intranet"
RUN dotnet build "Housematica.Intranet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Housematica.Intranet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Housematica.Intranet.dll"]