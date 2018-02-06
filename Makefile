all:
	dotnet build

./bin/Debug/netcoreapp2.0/jetServer.dll: ./src/Program.cs ./src/Util.cs ./src/Log.cs
	dotnet build

run:
	dotnet run
