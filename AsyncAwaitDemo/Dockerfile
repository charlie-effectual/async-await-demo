#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AsyncAwaitDemo.csproj", "."]
RUN dotnet restore "./AsyncAwaitDemo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AsyncAwaitDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsyncAwaitDemo.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsyncAwaitDemo.dll"]