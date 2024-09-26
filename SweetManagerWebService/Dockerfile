FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID

# Set environment variables and work directory

WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["SweetManagerWebService/SweetManagerWebService.csproj", "SweetManagerWebService/"]
RUN dotnet restore "SweetManagerWebService/SweetManagerWebService.csproj"

# Copy the remaining source code and build the application
COPY . .
WORKDIR "/src/SweetManagerWebService"
RUN dotnet build "SweetManagerWebService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SweetManagerWebService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
# Copy the published output from the build stage

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SweetManagerWebService.dll"]
