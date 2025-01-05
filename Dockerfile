
# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["src/LinuxMonitoring/LinuxMonitoring.csproj", "LinuxMonitoring/"]
RUN dotnet restore "./LinuxMonitoring/LinuxMonitoring.csproj"

# Copy the entire source code
COPY ./src/ .

# Build the application
WORKDIR "/src/LinuxMonitoring"
RUN dotnet build "LinuxMonitoring.csproj" -c $BUILD_CONFIGURATION -o /app/build



# Stage 2: Runtime environment
FROM ubuntu:latest AS runtime

# Set timezone and prevent interactive prompts
ENV TZ=Asia/Tehran
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone \
    && apt-get update && apt-get install -y --no-install-recommends \
    dos2unix zlib1g aspnetcore-runtime-8.0 dotnet-runtime-8.0 sysstat bc \
    && apt-get clean && rm -rf /var/lib/apt/lists/*

# Set working directory
WORKDIR /app

# Copy scripts and static files
COPY ./scripts/ ./scripts/
COPY ./src/LinuxMonitoring/wwwroot /app/wwwroot

RUN dos2unix ./scripts/Cpu/* \
    ./scripts/Disk/* \
    ./scripts/General/* \
    ./scripts/Memory/* \
    ./scripts/Network/*

# Copy build output from build stage
COPY --from=build /app/build /app

# Expose the application port
EXPOSE 5130

# Run the application
ENTRYPOINT ["dotnet", "LinuxMonitoring.dll"]