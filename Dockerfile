FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["src/LinuxMonitoring/LinuxMonitoring.csproj", "LinuxMonitoring/"]
RUN dotnet restore "./LinuxMonitoring/LinuxMonitoring.csproj"

# Copy the entire source code and scripts directory
COPY ./src/ .
COPY ./scripts/ ./scripts/

# Set the working directory to the project and build the application
WORKDIR "/src/LinuxMonitoring"
RUN dotnet build "LinuxMonitoring.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Expose the application port
EXPOSE 5130
