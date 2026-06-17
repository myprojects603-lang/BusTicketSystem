# Bus Ticket Management System - Enterprise Edition

## Project Overview

A production-grade, enterprise-level Bus Ticket & Transport Management System built with:
- **Backend:** ASP.NET Core 3.1 Web API
- **Frontend:** Angular 16
- **Database:** SQL Server with Dapper ORM
- **Architecture:** Clean Architecture with Repository and Unit of Work patterns

## Key Features

### Core Functionality
- 🎟️ Ticket Booking & Cancellation System
- 🚌 Bus Fleet Management
- 🛣️ Route & Schedule Management
- 👥 Driver & Hostess Management
- 💳 Payment Processing with Refund Engine
- 📊 Advanced Reporting & Analytics

### Enterprise Features
- 🔐 Enhanced Security (Account Lockout, 2FA, Password Policy)
- 📝 Comprehensive Audit Logging
- 🔄 Real-time Updates with SignalR
- 📧 Multi-channel Notifications (Email/SMS)
- ⚡ Performance Optimization (Caching, Rate Limiting)
- 📈 Advanced Reporting with Scheduling
- 🛡️ Global Error Handling
- 📱 Real-time Dashboard

## Technology Stack

### Backend
- ASP.NET Core 3.1
- Dapper (Micro ORM)
- SQL Server
- Entity Framework for Identity
- SignalR for Real-time
- Redis for Caching
- Serilog for Logging

### Frontend
- Angular 16
- Angular Material
- Bootstrap 5
- ngx-toastr for Notifications
- Chart.js for Analytics

## Project Structure

```
BusTicketManagementSystem/
├── BusTicketManagementSystem.Domain/           # Domain entities & interfaces
├── BusTicketManagementSystem.Application/      # DTOs, Services, Mappings
├── BusTicketManagementSystem.Infrastructure/   # Dapper repos, UnitOfWork
├── BusTicketManagementSystem.API/              # ASP.NET Core Web API
├── BusTicketManagementSystem.Reporting/        # PDF/Excel reports
├── BusTicketManagementSystem.Shared/           # Shared models
├── BusTicketManagementSystem.Web/              # Angular 16 frontend
└── Database/                                    # SQL Server scripts
```

## Getting Started

### Prerequisites
- .NET Core 3.1 SDK
- SQL Server 2019+
- Node.js 16+
- Angular CLI 16

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/myprojects603-lang/BusTicketSystem.git
cd BusTicketSystem
```

2. **Setup Backend**
```bash
# Restore NuGet packages
dotnet restore

# Build solution
dotnet build
```

3. **Setup Database**
- Run SQL Server scripts from `Database/` folder
- Update connection string in `appsettings.json`

4. **Setup Frontend**
```bash
cd BusTicketManagementSystem.Web
npm install
ng serve
```

## API Documentation

API Swagger documentation available at: `http://localhost:5000/swagger`

## Database

Database scripts include:
- 18 Tables (Identity, Bus, Route, Schedule, Booking, Payment, Driver, Hostess, etc.)
- Indexes for performance
- Stored Procedures for critical operations
- Seed data

## Security

- JWT Authentication with Refresh Token
- Role-based Authorization (Admin, Staff, Customer, Driver, Hostess)
- Account Lockout after failed login attempts
- IP Address & Device Fingerprint tracking
- Password Policy enforcement
- 2FA support (Email/SMS OTP)

## Deployment

See `DEPLOYMENT_GUIDE.md` for production deployment instructions.

## Contributing

This is a complete production system. All features are implemented.

## License

Commercial - All Rights Reserved
