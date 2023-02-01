# Use the latest .NET 7 image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0

# Set the working directory in the container
WORKDIR /opt/app

# Copy the application files to the working directory
COPY src/WebApi1 .

# Restore the .NET dependencies
RUN dotnet restore

# Build the .NET application
RUN dotnet build
# RUN dotnet build -c Debug

# Publish the .NET application
# RUN dotnet publish -c Debug -o ./out
RUN dotnet publish -o ./out

# Set the working directory to the published output
# WORKDIR /opt/app
WORKDIR /opt/app/out

# Expose port 80 in the container
# EXPOSE 80

# Set the entrypoint to run the .NET application
ENTRYPOINT ["dotnet", "WebApi1.dll"]
# ENTRYPOINT ["dotnet", "run", "-c", "Debug"]
# ENTRYPOINT ["dotnet", "run", "WebApi1.dll", "-c", "Debug"]
