# Run a dotnet image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["src/LinuxMonitoring/LinuxMonitoring.csproj", "LinuxMonitoring/"]
RUN dotnet restore "./LinuxMonitoring/LinuxMonitoring.csproj"

# Copy the entire source code and scripts directory
COPY ./src/ .

# Set the working directory to the project and build the application
WORKDIR "/src/LinuxMonitoring"
RUN dotnet build "LinuxMonitoring.csproj" -c $BUILD_CONFIGURATION -o /app/build

#ٔ Run Ubuntu image to run the project
FROM ubuntu:latest AS runtime

# Set the working directory and set entry point
WORKDIR /app
COPY ./scripts/ ./scripts/

#Install dotnet dependencies
RUN apt-get update
RUN apt-get install zlib1g
RUN apt-get install -y aspnetcore-runtime-8.0
RUN apt-get install -y dotnet-runtime-8.0

# Install scripts dependencies
RUN DEBIAN_FRONTEND="noninteractive" TZ="America/New_York" && apt-get install -y sysstat && apt-get install nano

# Copy the build output from the first stage
COPY --from=build /app/build /app

# Run the project
ENTRYPOINT ["dotnet", "LinuxMonitoring.dll"]

# Expose the application port
EXPOSE 5130

