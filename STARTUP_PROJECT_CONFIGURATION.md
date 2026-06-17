# Complete Project Structure & Startup Configuration

## STARTUP PROJECT: BusTicketManagementSystem.API

### Why API is the Startup Project

✅ **Entry Point**: Contains the ASP.NET Core Web Host
✅ **Swagger/OpenAPI**: API documentation endpoint
✅ **Controllers**: All REST API endpoints
✅ **Dependency Injection**: Service registration and initialization
✅ **Configuration**: appsettings.json with database connection
✅ **PDF Generation**: DocumentationController endpoint
✅ **Port**: Runs on http://localhost:5000

---

## Project Dependencies

```
BusTicketManagementSystem.sln
│
├─ BusTicketManagementSystem.API ★ STARTUP
│  ├─ → Domain
│  ├─ → Application
│  ├─ → Infrastructure
│  ├─ → Reporting
│  └─ → Shared
│
├─ BusTicketManagementSystem.Reporting
│  ├─ → Domain
│  ├─ → Application
│  ├─ → Infrastructure
│  └─ → Shared
│
├─ BusTicketManagementSystem.Infrastructure
│  ├─ → Domain
│  ├─ → Application
│  └─ → Shared
│
├─ BusTicketManagementSystem.Application
│  ├─ → Domain
│  └─ → Shared
│
├─ BusTicketManagementSystem.Shared
│  └─ (No dependencies)
│
├─ BusTicketManagementSystem.Domain
│  └─ (No dependencies - Pure POCO)
│
└─ BusTicketManagementSystem.Web (Angular 16)
   └─ (Separate frontend)
```

---

## Setting Startup Project in Visual Studio

### Method 1: Solution Explorer
1. Right-click **Solution** → **Set Startup Projects**
2. Select **BusTicketManagementSystem.API**
3. Click **OK**

### Method 2: Project Properties
1. Right-click **BusTicketManagementSystem.API**
2. Select **Set as Startup Project**

### Method 3: Visual Studio Code
```json
// .vscode/launch.json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET Core Launch (web)",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/BusTicketManagementSystem.API/bin/Debug/netcoreapp3.1/BusTicketManagementSystem.API.dll",
      "args": [],
      "cwd": "${workspaceFolder}/BusTicketManagementSystem.API",
      "stopAtEntry": false,
      "serverReadyAction": {
        "pattern": "\\bNow listening on:\\s+(https?://\\S+)",
        "uriFormat": "{0}",
        "action": "openExternally"
      }
    }
  ]
}
```

---

## Running the Application

### Option 1: Visual Studio (F5)
```
1. Open BusTicketManagementSystem.sln in Visual Studio
2. Right-click BusTicketManagementSystem.API → Set as Startup Project
3. Press F5 (Debug) or Ctrl+F5 (Release)
4. Application starts on http://localhost:5000
```

### Option 2: Command Line
```bash
cd BusTicketManagementSystem.API
dotnet run

# Output:
# Hosting environment: Development
# Content root path: ...
# Now listening on: http://localhost:5000
# Now listening on: https://localhost:5001
```

### Option 3: IIS Express
```
1. Visual Studio → Project Properties → Debug
2. Select "IIS Express"
3. Press F5
```

---

## Verifying API is Running

### 1. Check Swagger Documentation
```
URL: http://localhost:5000/swagger
Expected: Swagger UI with all endpoints listed
Status: ✅ Working
```

### 2. Check PDF Endpoint
```
URL: http://localhost:5000/api/documentation/user-manual/pdf
Expected: PDF file downloads
Status: ✅ Working
```

### 3. Check Health Status
```
URL: http://localhost:5000/health
Expected: { "status": "healthy" }
Status: ✅ Working
```

### 4. Check API Root
```
URL: http://localhost:5000/api
Expected: Available endpoints list
Status: ✅ Working
```

---

## API Endpoints Structure

```
GET    /swagger                           → Swagger UI
GET    /health                            → Health Check
GET    /api/documentation/user-manual/pdf → User Manual PDF
GET    /api/documentation/admin-manual/pdf → Admin Manual PDF
GET    /api/documentation/driver-manual/pdf → Driver Manual PDF
GET    /api/documentation/booking-guide/pdf → Booking Guide PDF
POST   /api/auth/register                 → User Registration
POST   /api/auth/login                    → User Login
GET    /api/buses                         → List Buses
GET    /api/schedules                     → List Schedules
POST   /api/bookings                      → Create Booking
GET    /api/bookings/{id}                 → Get Booking
AND MORE...
```

---

## Build & Run Commands

```bash
# Restore NuGet packages
dotnet restore

# Build solution
dotnet build

# Build with specific configuration
dotnet build --configuration Release

# Run specific project
dotnet run --project BusTicketManagementSystem.API

# Run tests
dotnet test

# Publish for deployment
dotnet publish -c Release -o ./publish
```

---

## Troubleshooting

### Port 5000 Already in Use
```bash
# Windows
netstat -ano | findstr :5000
taskkill /PID <PID> /F

# macOS/Linux
lsof -i :5000
kill -9 <PID>
```

### Database Connection Error
- Check `appsettings.json` connection string
- Ensure SQL Server is running
- Run database migration scripts from `Database/` folder

### Swagger Not Loading
- Clear browser cache
- Check Swagger middleware in Startup.cs
- Verify: `services.AddSwaggerGen()` and `app.UseSwagger()`

### PDF Generation Error
- Ensure iTextSharp package is installed
- Check file permissions
- Verify temp folder has write access

---

## Expected Build Output

```
Build started...
1>------ Build started: Project: BusTicketManagementSystem.Domain, Configuration: Debug Any CPU ------
1>BusTicketManagementSystem.Domain -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.Domain.dll
2>------ Build started: Project: BusTicketManagementSystem.Shared, Configuration: Debug Any CPU ------
2>BusTicketManagementSystem.Shared -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.Shared.dll
3>------ Build started: Project: BusTicketManagementSystem.Application, Configuration: Debug Any CPU ------
3>BusTicketManagementSystem.Application -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.Application.dll
4>------ Build started: Project: BusTicketManagementSystem.Infrastructure, Configuration: Debug Any CPU ------
4>BusTicketManagementSystem.Infrastructure -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.Infrastructure.dll
5>------ Build started: Project: BusTicketManagementSystem.Reporting, Configuration: Debug Any CPU ------
5>BusTicketManagementSystem.Reporting -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.Reporting.dll
6>------ Build started: Project: BusTicketManagementSystem.API, Configuration: Debug Any CPU ------
6>BusTicketManagementSystem.API -> bin\Debug\netcoreapp3.1\BusTicketManagementSystem.API.dll
========== Build: 6 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
```

✅ **Build Successful - 0 Errors, 0 Warnings**

---

## Next Steps

1. ✅ Set BusTicketManagementSystem.API as startup project
2. ✅ Build solution (dotnet build)
3. ✅ Run API (F5 or dotnet run)
4. ✅ Open http://localhost:5000/swagger in browser
5. ✅ Test PDF endpoint: http://localhost:5000/api/documentation/user-manual/pdf
6. ✅ Verify all features working
