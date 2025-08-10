BluestarTech Complaint Management - Full Project ZIP
---------------------------------------------------

What's included:
- bluestartech-backend: ASP.NET Core Web API scaffold (source files)
- bluestartech-frontend: Vite + React + Tailwind scaffold (source files)
- docker-compose.yml to bring up SQL Server, backend, and frontend

How to run (with Docker):
1. Install Docker on your machine.
2. From this repo root run:
   docker-compose up --build
3. Backend API will be available at http://localhost:5000
   Frontend dev preview at http://localhost:5173

Notes:
- You must create the actual .NET project/solution files if you want to build the backend locally with dotnet CLI.
- The scaffold provides source code files; adjust namespaces/project files as needed for compilation.
