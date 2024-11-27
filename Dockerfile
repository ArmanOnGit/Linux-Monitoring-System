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

#ٔNow load the Ubuntu
FROM ubuntu:latest AS runtime

#Install dotnet dependencies
RUN apt-get update && apt-get install zlib1g
RUN apt-get install -y aspnetcore-runtime-8.0
RUN apt-get install -y dotnet-runtime-8.0
# Copy the build output from the first stage
COPY --from=build /app/build /app

# Set the working directory and set entry point
WORKDIR /app
COPY ./scripts/ ./scripts/

#ENTRYPOINT ["dotnet", "LinuxMonitoring.dll"]

# Expose the application port
EXPOSE 5130

