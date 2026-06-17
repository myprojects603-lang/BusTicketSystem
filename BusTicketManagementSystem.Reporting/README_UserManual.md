# User Manual PDF Generator & Documentation Module

## Overview

This module provides comprehensive PDF generation capabilities for user manuals and documentation.

## Components

### 1. IUserManualService Interface

Defines methods for generating different types of PDF manuals:

```csharp
public interface IUserManualService
{
    Task<byte[]> GenerateUserManualPdfAsync();
    Task<byte[]> GenerateAdminManualPdfAsync();
    Task<byte[]> GenerateDriverManualPdfAsync();
    Task<byte[]> GenerateBookingGuidePdfAsync();
}
```

### 2. UserManualService Implementation

Generates comprehensive PDF documents with:

- **Professional Formatting**: iTextSharp-based PDF generation
- **Multiple Manuals**:
  - Customer User Manual (14 chapters)
  - Administrator Manual (10 chapters)
  - Driver Manual (5 chapters)
  - Booking Quick Guide (5 chapters)

- **Content Structure**:
  - Title pages
  - Table of contents
  - Step-by-step instructions
  - Screenshot placeholders
  - Formatted tables and lists
  - FAQ sections
  - Troubleshooting guides

### 3. DocumentationController

REST API endpoints for PDF download:

```
GET /api/documentation/user-manual/pdf          → Customer Manual (Public)
GET /api/documentation/admin-manual/pdf         → Admin Manual (Admin Only)
GET /api/documentation/driver-manual/pdf        → Driver Manual (Driver Only)
GET /api/documentation/booking-guide/pdf        → Quick Guide (Public)
```

## Customer User Manual Chapters

1. **Introduction** - Welcome and key features
2. **System Requirements** - Browser, connection, device specs
3. **Login Process** - Step-by-step login guide with 2FA
4. **Dashboard Overview** - Main dashboard sections
5. **Searching Buses** - How to search for buses
6. **Booking Process** - Complete booking workflow
7. **Seat Selection** - Interactive seat selection
8. **Payment Process** - Multiple payment methods
9. **Booking Confirmation** - What to expect after booking
10. **Cancellation Process** - Cancellation policy and steps
11. **My Bookings** - Managing your bookings
12. **Profile Management** - Updating personal information
13. **Notifications** - Notification types and settings
14. **FAQ & Troubleshooting** - Common questions and solutions

## Administrator Manual Chapters

1. **Admin Dashboard Overview** - Dashboard metrics and features
2. **Bus Management** - Adding and managing buses
3. **Route Management** - Creating and managing routes
4. **Schedule Management** - Creating bus schedules
5. **User Management** - Managing user accounts and roles
6. **Driver Management** - Managing driver profiles
7. **Payment & Refund Management** - Payment handling
8. **Reports & Analytics** - Available reports and export
9. **System Settings** - Configuration options
10. **Audit Logs** - System activity tracking

## Driver Manual Chapters

1. **Introduction for Drivers** - Welcome and features
2. **Profile Setup** - Complete driver profile
3. **View Your Assignments** - Check scheduled routes
4. **Manage Your Schedule** - Schedule requests and availability
5. **Safety Guidelines** - Safety protocols and procedures

## Booking Quick Guide Chapters

1. **Getting Started** - Prerequisites and overview
2. **Searching for Tickets** - Search steps
3. **Complete Booking Steps** - 5-step booking process
4. **Payment Guide** - Payment methods and security
5. **Cancellation Policy** - Refund table and policy

## Usage

### In Angular Frontend

```typescript
// Download user manual
window.location.href = `${environment.apiUrl}/documentation/user-manual/pdf`;

// Download booking guide
window.location.href = `${environment.apiUrl}/documentation/booking-guide/pdf`;
```

### In Postman

```
GET http://localhost:5000/api/documentation/user-manual/pdf
GET http://localhost:5000/api/documentation/admin-manual/pdf
GET http://localhost:5000/api/documentation/driver-manual/pdf
GET http://localhost:5000/api/documentation/booking-guide/pdf
```

## Features

✅ **Professional PDF Generation**
- Clean, formatted layouts
- Table of contents
- Page numbering
- Proper font sizing and styles

✅ **Screenshot Placeholders**
- [SCREENSHOT-LOGIN]
- [SCREENSHOT-DASHBOARD]
- [SCREENSHOT-BOOKING]
- [SCREENSHOT-PAYMENT]
- And many more...

✅ **Multiple Export Formats**
- PDF (Primary)
- Can be extended for Word, Excel

✅ **Role-Based Access**
- Admin manual requires Admin role
- Driver manual requires Driver role
- Customer manual and booking guide are public

✅ **Dynamic Generation**
- Generated on-demand
- Includes current date
- Can be customized with company info

## Screenshot Placeholder Reference

The PDFs include placeholders for screenshots that can be replaced with actual images:

- **LOGIN_PAGE** - Login screen
- **DASHBOARD** - Main dashboard
- **SEARCH_BUSES** - Bus search results
- **BOOKING_PROCESS** - Booking workflow
- **SEAT_SELECTION** - Seat selection interface
- **PAYMENT_PAGE** - Payment form
- **BOOKING_CONFIRMATION** - Confirmation screen
- **MY_BOOKINGS** - Bookings list
- **ADMIN_DASHBOARD** - Admin dashboard
- **AND MORE...**

## Future Enhancements

- [ ] Add actual screenshots from the application
- [ ] Generate Word documents
- [ ] Video tutorials integration
- [ ] Multi-language support
- [ ] Email PDF delivery
- [ ] Scheduled PDF generation
- [ ] Custom branding per company

## Dependencies

- iTextSharp.LGPLv2.Core (for PDF generation)
- .NET Core 3.1
- ASP.NET Core
