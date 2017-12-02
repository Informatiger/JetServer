all:
	dotnet build
	dotnet run
	
./bin/Debug/netcoreapp2.0/jetServer.dll: Program.cs Util.cs Log.cs
	dotnet build

run:
	dotnet run
