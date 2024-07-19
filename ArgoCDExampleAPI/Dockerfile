# Use the official .NET Core SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port and start the application
EXPOSE 80
ENTRYPOINT ["dotnet", "ArgoCDExampleAPI.dll"]