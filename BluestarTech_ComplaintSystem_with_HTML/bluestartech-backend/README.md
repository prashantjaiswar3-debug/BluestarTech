BluestarTech Backend
--------------------

This is a scaffolded ASP.NET Core Web API (source files included).

To run locally (without Docker):
1. Install .NET 8 SDK
2. Set the connection string in appsettings.json
3. From the bluestartech-backend folder run:
   dotnet restore
   dotnet run

Docker:
  docker build -t bluestar-backend ./bluestartech-backend
  docker run --rm -p 5000:80 --env ConnectionStrings__DefaultConnection="Server=sqlserver;Database=BluestarTechComplaints;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;" bluestar-backend
