#!/bin/bash

docker stop test-dotnet-api
docker rm test-dotnet-api
docker image rm test-dotnet-api-image

docker build -t test-dotnet-api-image .
# docker run --network network1 -p 80:80 test-dotnet-api-image
docker run -d --name test-dotnet-api -p 8081:8081 test-dotnet-api-image
