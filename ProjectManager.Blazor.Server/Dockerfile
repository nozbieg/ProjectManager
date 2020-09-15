#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProjectManager.Blazor.Server/ProjectManager.Blazor.Server.csproj", "ProjectManager.Blazor.Server/"]
COPY ["ProjectManager.Module/ProjectManager.Module.csproj", "ProjectManager.Module/"]
COPY ["ProjectManager.Module.Blazor/ProjectManager.Module.Blazor.csproj", "ProjectManager.Module.Blazor/"]
RUN dotnet restore "ProjectManager.Blazor.Server/ProjectManager.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/ProjectManager.Blazor.Server"
RUN dotnet build "ProjectManager.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManager.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManager.Blazor.Server.dll"]