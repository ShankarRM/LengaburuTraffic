dotnet restore
dotnet build
dotnet test .\Lengaburu.Test -v n --no-build --no-restore
dotnet run --project .\LengaburuTraffic\LengaburuTraffic.csproj


