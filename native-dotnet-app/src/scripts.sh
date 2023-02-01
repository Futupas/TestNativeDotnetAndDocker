dotnet publish -c Release -o bin/Release/publish
# dotnet /home/futupas/projects/test-docker-and-dotnet/native-dotnet-app/src/WebApi1/bin/Release/publish/WebApi1.dll --urls "http://0.0.0.0:8082" &
dotnet /home/futupas/projects/test-docker-and-dotnet/native-dotnet-app/src/WebApi1/bin/Release/publish/WebApi1.dll --urls "http://0.0.0.0:8082" & disown
netstat -tulpn

http://192.168.0.101:8082/endpoint1