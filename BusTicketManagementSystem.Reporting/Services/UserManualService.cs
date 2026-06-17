using System;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BusTicketManagementSystem.Reporting.Services
{
    /// <summary>
    /// Service for generating comprehensive user manual PDF documents.
    /// Includes step-by-step guides, screenshots, and troubleshooting.
    /// </summary>
    public interface IUserManualService
    {
        Task<byte[]> GenerateUserManualPdfAsync();
        Task<byte[]> GenerateAdminManualPdfAsync();
        Task<byte[]> GenerateDriverManualPdfAsync();
        Task<byte[]> GenerateBookingGuidePdfAsync();
    }

    public class UserManualService : IUserManualService
    {
        public async Task<byte[]> GenerateUserManualPdfAsync()
        {
            return await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    // Title Page
                    AddTitlePage(doc);

                    // Table of Contents
                    doc.NewPage();
                    AddTableOfContents(doc);

                    // Chapter 1: Introduction
                    doc.NewPage();
                    AddChapter1_Introduction(doc);

                    // Chapter 2: System Requirements
                    doc.NewPage();
                    AddChapter2_SystemRequirements(doc);

                    // Chapter 3: Login Process
                    doc.NewPage();
                    AddChapter3_LoginProcess(doc);

                    // Chapter 4: Dashboard Overview
                    doc.NewPage();
                    AddChapter4_DashboardOverview(doc);

                    // Chapter 5: Searching Buses
                    doc.NewPage();
                    AddChapter5_SearchingBuses(doc);

                    // Chapter 6: Booking Process
                    doc.NewPage();
                    AddChapter6_BookingProcess(doc);

                    // Chapter 7: Seat Selection
                    doc.NewPage();
                    AddChapter7_SeatSelection(doc);

                    // Chapter 8: Payment Process
                    doc.NewPage();
                    AddChapter8_PaymentProcess(doc);

                    // Chapter 9: Booking Confirmation
                    doc.NewPage();
                    AddChapter9_BookingConfirmation(doc);

                    // Chapter 10: Cancellation Process
                    doc.NewPage();
                    AddChapter10_CancellationProcess(doc);

                    // Chapter 11: My Bookings
                    doc.NewPage();
                    AddChapter11_MyBookings(doc);

                    // Chapter 12: Profile Management
                    doc.NewPage();
                    AddChapter12_ProfileManagement(doc);

                    // Chapter 13: Notifications
                    doc.NewPage();
                    AddChapter13_Notifications(doc);

                    // Chapter 14: FAQ & Troubleshooting
                    doc.NewPage();
                    AddChapter14_FAQ(doc);

                    doc.Close();
                    return ms.ToArray();
                }
            });
        }

        public async Task<byte[]> GenerateAdminManualPdfAsync()
        {
            return await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    AddAdminTitlePage(doc);
                    doc.NewPage();
                    AddAdminChapter1_Overview(doc);
                    doc.NewPage();
                    AddAdminChapter2_BusManagement(doc);
                    doc.NewPage();
                    AddAdminChapter3_RouteManagement(doc);
                    doc.NewPage();
                    AddAdminChapter4_ScheduleManagement(doc);
                    doc.NewPage();
                    AddAdminChapter5_UserManagement(doc);
                    doc.NewPage();
                    AddAdminChapter6_DriverManagement(doc);
                    doc.NewPage();
                    AddAdminChapter7_PaymentManagement(doc);
                    doc.NewPage();
                    AddAdminChapter8_Reports(doc);
                    doc.NewPage();
                    AddAdminChapter9_SystemSettings(doc);
                    doc.NewPage();
                    AddAdminChapter10_AuditLogs(doc);

                    doc.Close();
                    return ms.ToArray();
                }
            });
        }

        public async Task<byte[]> GenerateDriverManualPdfAsync()
        {
            return await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    AddDriverTitlePage(doc);
                    doc.NewPage();
                    AddDriverChapter1_Introduction(doc);
                    doc.NewPage();
                    AddDriverChapter2_ProfileSetup(doc);
                    doc.NewPage();
                    AddDriverChapter3_ViewAssignments(doc);
                    doc.NewPage();
                    AddDriverChapter4_ManageSchedule(doc);
                    doc.NewPage();
                    AddDriverChapter5_SafetyGuidelines(doc);

                    doc.Close();
                    return ms.ToArray();
                }
            });
        }

        public async Task<byte[]> GenerateBookingGuidePdfAsync()
        {
            return await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    AddBookingGuideTitlePage(doc);
                    doc.NewPage();
                    AddBookingGuideChapter1_GettingStarted(doc);
                    doc.NewPage();
                    AddBookingGuideChapter2_SearchingTickets(doc);
                    doc.NewPage();
                    AddBookingGuideChapter3_BookingSteps(doc);
                    doc.NewPage();
                    AddBookingGuideChapter4_PaymentGuide(doc);
                    doc.NewPage();
                    AddBookingGuideChapter5_CancellationPolicy(doc);

                    doc.Close();
                    return ms.ToArray();
                }
            });
        }

        #region Title Pages

        private void AddTitlePage(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 32, Font.BOLD);
            Font subtitleFont = new Font(Font.HELVETICA, 18, Font.NORMAL);
            Font dateFont = new Font(Font.HELVETICA, 12, Font.ITALIC);

            Paragraph title = new Paragraph("Bus Ticket Management System", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph subtitle = new Paragraph("Customer User Manual", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            doc.Add(subtitle);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph version = new Paragraph("Version 1.0", dateFont);
            version.Alignment = Element.ALIGN_CENTER;
            doc.Add(version);

            Paragraph date = new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy}", dateFont);
            date.Alignment = Element.ALIGN_CENTER;
            doc.Add(date);
        }

        private void AddAdminTitlePage(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 32, Font.BOLD);
            Font subtitleFont = new Font(Font.HELVETICA, 18, Font.NORMAL);

            Paragraph title = new Paragraph("Bus Ticket Management System", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(" "));

            Paragraph subtitle = new Paragraph("Administrator Manual", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            doc.Add(subtitle);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy}"));
        }

        private void AddDriverTitlePage(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 32, Font.BOLD);
            Font subtitleFont = new Font(Font.HELVETICA, 18, Font.NORMAL);

            Paragraph title = new Paragraph("Bus Ticket Management System", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(" "));

            Paragraph subtitle = new Paragraph("Driver Manual", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            doc.Add(subtitle);
        }

        private void AddBookingGuideTitlePage(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 32, Font.BOLD);
            Font subtitleFont = new Font(Font.HELVETICA, 18, Font.NORMAL);

            Paragraph title = new Paragraph("How to Book a Ticket", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(" "));

            Paragraph subtitle = new Paragraph("Quick Start Guide", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            doc.Add(subtitle);
        }

        #endregion

        #region Table of Contents

        private void AddTableOfContents(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 16, Font.BOLD);
            Font contentFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("Table of Contents", headingFont);
            heading.SpacingAfter = 20;
            doc.Add(heading);

            string[] chapters = new[]
            {
                "1.  Introduction",
                "2.  System Requirements",
                "3.  Login Process",
                "4.  Dashboard Overview",
                "5.  Searching Buses",
                "6.  Booking Process",
                "7.  Seat Selection",
                "8.  Payment Process",
                "9.  Booking Confirmation",
                "10. Cancellation Process",
                "11. My Bookings",
                "12. Profile Management",
                "13. Notifications",
                "14. FAQ & Troubleshooting"
            };

            foreach (var chapter in chapters)
            {
                Paragraph p = new Paragraph(chapter, contentFont);
                p.SpacingAfter = 8;
                doc.Add(p);
            }
        }

        #endregion

        #region Customer Chapters

        private void AddChapter1_Introduction(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("1. Introduction", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Welcome to the Bus Ticket Management System! This comprehensive guide will help you navigate through the system and complete your bus ticket bookings efficiently.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Key Features:", new Font(Font.HELVETICA, 11, Font.BOLD)));

            doc.Add(new Paragraph("• Easy-to-use interface for searching and booking bus tickets", bodyFont));
            doc.Add(new Paragraph("• Real-time seat availability updates", bodyFont));
            doc.Add(new Paragraph("• Secure payment processing", bodyFont));
            doc.Add(new Paragraph("• Multiple payment options", bodyFont));
            doc.Add(new Paragraph("• Instant booking confirmation", bodyFont));
            doc.Add(new Paragraph("• Flexible cancellation policy", bodyFont));
            doc.Add(new Paragraph("• 24/7 customer support", bodyFont));
        }

        private void AddChapter2_SystemRequirements(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("2. System Requirements", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("To access the Bus Ticket Management System, ensure you have:", bodyFont));
            doc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 30, 70 });

            PdfPCell cell1 = new PdfPCell(new Phrase("Requirement", new Font(Font.HELVETICA, 11, Font.BOLD)));
            PdfPCell cell2 = new PdfPCell(new Phrase("Specification", new Font(Font.HELVETICA, 11, Font.BOLD)));
            table.AddCell(cell1);
            table.AddCell(cell2);

            table.AddCell(new PdfPCell(new Phrase("Browser", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Chrome, Firefox, Safari, Edge (Latest versions)", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("Internet Connection", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Minimum 2 Mbps for smooth operation", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("Device", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Desktop, Laptop, Tablet, or Smartphone", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("JavaScript", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Must be enabled in your browser", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("Cookies", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Must be enabled for session management", bodyFont)));

            doc.Add(table);
        }

        private void AddChapter3_LoginProcess(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font subheadFont = new Font(Font.HELVETICA, 12, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("3. Login Process", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            Paragraph step1 = new Paragraph("Step 1: Access the Login Page", subheadFont);
            step1.SpacingBefore = 12;
            step1.SpacingAfter = 6;
            doc.Add(step1);
            doc.Add(new Paragraph("Visit the application URL in your browser. The login page will display with two input fields: Username and Password.", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "LOGIN_PAGE");

            Paragraph step2 = new Paragraph("Step 2: Enter Credentials", subheadFont);
            step2.SpacingBefore = 12;
            step2.SpacingAfter = 6;
            doc.Add(step2);
            doc.Add(new Paragraph("• Enter your registered username", bodyFont));
            doc.Add(new Paragraph("• Enter your password", bodyFont));
            doc.Add(new Paragraph("• Click the 'Login' button", bodyFont));

            Paragraph step3 = new Paragraph("Step 3: Two-Factor Authentication (if enabled)", subheadFont);
            step3.SpacingBefore = 12;
            step3.SpacingAfter = 6;
            doc.Add(step3);
            doc.Add(new Paragraph("If 2FA is enabled, you'll receive an OTP (One-Time Password) via email or SMS. Enter this code to complete login.", bodyFont));
        }

        private void AddChapter4_DashboardOverview(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font subheadFont = new Font(Font.HELVETICA, 12, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("4. Dashboard Overview", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("After successful login, you'll see the main dashboard with the following sections:", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "DASHBOARD");

            Paragraph section1 = new Paragraph("Welcome Section", subheadFont);
            section1.SpacingBefore = 12;
            section1.SpacingAfter = 6;
            doc.Add(section1);
            doc.Add(new Paragraph("Displays a personalized greeting with your name and profile information.", bodyFont));

            Paragraph section2 = new Paragraph("Quick Search", subheadFont);
            section2.SpacingBefore = 12;
            section2.SpacingAfter = 6;
            doc.Add(section2);
            doc.Add(new Paragraph("Quick search box to find bus routes based on source and destination cities.", bodyFont));

            Paragraph section3 = new Paragraph("Recent Bookings", subheadFont);
            section3.SpacingBefore = 12;
            section3.SpacingAfter = 6;
            doc.Add(section3);
            doc.Add(new Paragraph("Shows your last 5 bookings with status information.", bodyFont));
        }

        private void AddChapter5_SearchingBuses(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("5. Searching Buses", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("To search for available buses:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("1. Select 'Source City' from the dropdown", bodyFont));
            doc.Add(new Paragraph("2. Select 'Destination City' from the dropdown", bodyFont));
            doc.Add(new Paragraph("3. Choose your preferred travel date", bodyFont));
            doc.Add(new Paragraph("4. Click the 'Search' button", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "SEARCH_BUSES");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("The system will display all available buses with their timings, prices, and seat availability.", bodyFont));
        }

        private void AddChapter6_BookingProcess(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("6. Booking Process", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("After searching for buses, follow these steps to book:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("1. Click on the bus you want to book", bodyFont));
            doc.Add(new Paragraph("2. Review the bus details and pricing", bodyFont));
            doc.Add(new Paragraph("3. Select your seat(s)", bodyFont));
            doc.Add(new Paragraph("4. Enter passenger details", bodyFont));
            doc.Add(new Paragraph("5. Review booking summary", bodyFont));
            doc.Add(new Paragraph("6. Proceed to payment", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "BOOKING_PROCESS");
        }

        private void AddChapter7_SeatSelection(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("7. Seat Selection", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("The seat selection interface shows the bus layout with available and booked seats.", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "SEAT_SELECTION");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Green seats: Available for booking", bodyFont));
            doc.Add(new Paragraph("• Red seats: Already booked", bodyFont));
            doc.Add(new Paragraph("• Blue seats: Selected by you", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Click on available seats to select them. You can select multiple seats if booking for multiple passengers.", bodyFont));
        }

        private void AddChapter8_PaymentProcess(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("8. Payment Process", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("The system supports multiple payment methods:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Credit Card", bodyFont));
            doc.Add(new Paragraph("• Debit Card", bodyFont));
            doc.Add(new Paragraph("• Mobile Wallet", bodyFont));
            doc.Add(new Paragraph("• Bank Transfer", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "PAYMENT_PAGE");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("All payments are encrypted and secured with SSL encryption. Your payment details are never stored on our servers.", bodyFont));
        }

        private void AddChapter9_BookingConfirmation(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("9. Booking Confirmation", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("After successful payment, you'll receive:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Confirmation message on screen", bodyFont));
            doc.Add(new Paragraph("• Booking reference number", bodyFont));
            doc.Add(new Paragraph("• Email with ticket details", bodyFont));
            doc.Add(new Paragraph("• SMS notification (if enabled)", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "BOOKING_CONFIRMATION");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Save your booking reference number for future reference. You'll need it to check your booking status or cancel the ticket.", bodyFont));
        }

        private void AddChapter10_CancellationProcess(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("10. Cancellation Process", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Cancellation Policy:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Cancellation more than 48 hours before: 100% refund", bodyFont));
            doc.Add(new Paragraph("• Cancellation 24-48 hours before: 70% refund", bodyFont));
            doc.Add(new Paragraph("• Cancellation less than 24 hours before: No refund", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("How to Cancel:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("1. Go to 'My Bookings'", bodyFont));
            doc.Add(new Paragraph("2. Find the booking you want to cancel", bodyFont));
            doc.Add(new Paragraph("3. Click the 'Cancel' button", bodyFont));
            doc.Add(new Paragraph("4. Confirm the cancellation", bodyFont));
            doc.Add(new Paragraph("5. Refund will be processed within 5-7 business days", bodyFont));
        }

        private void AddChapter11_MyBookings(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("11. My Bookings", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("The 'My Bookings' section shows all your past and upcoming bookings.", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "MY_BOOKINGS");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("For each booking, you can:", bodyFont));
            doc.Add(new Paragraph("• View full details", bodyFont));
            doc.Add(new Paragraph("• Download e-ticket", bodyFont));
            doc.Add(new Paragraph("• Cancel booking (if eligible)", bodyFont));
            doc.Add(new Paragraph("• Track payment status", bodyFont));
        }

        private void AddChapter12_ProfileManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("12. Profile Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("To update your profile information:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("1. Click on 'Profile' in the menu", bodyFont));
            doc.Add(new Paragraph("2. Click 'Edit Profile'", bodyFont));
            doc.Add(new Paragraph("3. Update your information", bodyFont));
            doc.Add(new Paragraph("4. Click 'Save Changes'", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("You can update:", bodyFont));
            doc.Add(new Paragraph("• First and Last Name", bodyFont));
            doc.Add(new Paragraph("• Email Address", bodyFont));
            doc.Add(new Paragraph("• Phone Number", bodyFont));
            doc.Add(new Paragraph("• Profile Picture", bodyFont));
        }

        private void AddChapter13_Notifications(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("13. Notifications", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("The notification center displays all your alerts and updates.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("You'll receive notifications for:", bodyFont));
            doc.Add(new Paragraph("• Booking confirmations", bodyFont));
            doc.Add(new Paragraph("• Payment updates", bodyFont));
            doc.Add(new Paragraph("• Cancellation confirmations", bodyFont));
            doc.Add(new Paragraph("• Refund status", bodyFont));
            doc.Add(new Paragraph("• System updates", bodyFont));
        }

        private void AddChapter14_FAQ(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font qaFont = new Font(Font.HELVETICA, 11, Font.BOLD);
            Font ansFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("14. FAQ & Troubleshooting", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            Paragraph q1 = new Paragraph("Q: Can I modify my booking after confirmation?", qaFont);
            q1.SpacingBefore = 10;
            q1.SpacingAfter = 4;
            doc.Add(q1);
            doc.Add(new Paragraph("A: No, you cannot modify a booking. You need to cancel and create a new booking.", ansFont));
            doc.Add(new Paragraph(" "));

            Paragraph q2 = new Paragraph("Q: How long does refund processing take?", qaFont);
            q2.SpacingBefore = 10;
            q2.SpacingAfter = 4;
            doc.Add(q2);
            doc.Add(new Paragraph("A: Refunds are processed within 5-7 business days depending on your bank.", ansFont));
            doc.Add(new Paragraph(" "));

            Paragraph q3 = new Paragraph("Q: Is my payment information secure?", qaFont);
            q3.SpacingBefore = 10;
            q3.SpacingAfter = 4;
            doc.Add(q3);
            doc.Add(new Paragraph("A: Yes, all payments are encrypted with SSL 256-bit encryption. We do not store credit card details.", ansFont));
            doc.Add(new Paragraph(" "));

            Paragraph q4 = new Paragraph("Q: What if I forgot my password?", qaFont);
            q4.SpacingBefore = 10;
            q4.SpacingAfter = 4;
            doc.Add(q4);
            doc.Add(new Paragraph("A: Click 'Forgot Password' on the login page and follow the email instructions to reset your password.", ansFont));
        }

        #endregion

        #region Admin Chapters

        private void AddAdminChapter1_Overview(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("1. Admin Dashboard Overview", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("The admin dashboard provides comprehensive system management and monitoring tools.", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotPlaceholder(doc, "ADMIN_DASHBOARD");
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Key Dashboard Metrics:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Total Bookings: Count of all bookings in the system", bodyFont));
            doc.Add(new Paragraph("• Revenue: Total earnings from bookings", bodyFont));
            doc.Add(new Paragraph("• Active Buses: Number of buses currently in operation", bodyFont));
            doc.Add(new Paragraph("• Active Drivers: Number of drivers available", bodyFont));
            doc.Add(new Paragraph("• System Health: Overall system status", bodyFont));
        }

        private void AddAdminChapter2_BusManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("2. Bus Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Manage your bus fleet with comprehensive features:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Adding a New Bus:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("1. Click 'Add Bus' button", bodyFont));
            doc.Add(new Paragraph("2. Fill in bus details (name, registration, capacity)", bodyFont));
            doc.Add(new Paragraph("3. Set maintenance schedule", bodyFont));
            doc.Add(new Paragraph("4. Click 'Save'", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Updating Bus Information:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("1. Select the bus from the list", bodyFont));
            doc.Add(new Paragraph("2. Click 'Edit'", bodyFont));
            doc.Add(new Paragraph("3. Modify the details", bodyFont));
            doc.Add(new Paragraph("4. Click 'Save Changes'", bodyFont));
        }

        private void AddAdminChapter3_RouteManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("3. Route Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Create and manage routes for your bus operations.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Creating a New Route:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("1. Navigate to Routes section", bodyFont));
            doc.Add(new Paragraph("2. Click 'Add Route'", bodyFont));
            doc.Add(new Paragraph("3. Enter source and destination cities", bodyFont));
            doc.Add(new Paragraph("4. Set distance and estimated duration", bodyFont));
            doc.Add(new Paragraph("5. Click 'Create Route'", bodyFont));
        }

        private void AddAdminChapter4_ScheduleManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("4. Schedule Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Manage bus schedules and availability.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Creating a Schedule:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("1. Select a bus", bodyFont));
            doc.Add(new Paragraph("2. Select a route", bodyFont));
            doc.Add(new Paragraph("3. Set departure and arrival times", bodyFont));
            doc.Add(new Paragraph("4. Set ticket price", bodyFont));
            doc.Add(new Paragraph("5. Select travel dates", bodyFont));
            doc.Add(new Paragraph("6. Click 'Create Schedule'", bodyFont));
        }

        private void AddAdminChapter5_UserManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("5. User Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Manage user accounts and permissions.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("User Roles:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Admin: Full system access", bodyFont));
            doc.Add(new Paragraph("• Staff: Limited administrative access", bodyFont));
            doc.Add(new Paragraph("• Customer: Booking and profile access", bodyFont));
            doc.Add(new Paragraph("• Driver: Driver assignment and schedule viewing", bodyFont));
        }

        private void AddAdminChapter6_DriverManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("6. Driver Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Manage driver profiles and assignments.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Driver Information:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• License Number and Expiry Date", bodyFont));
            doc.Add(new Paragraph("• CNIC (National ID)", bodyFont));
            doc.Add(new Paragraph("• Years of Experience", bodyFont));
            doc.Add(new Paragraph("• Current Assignment Status", bodyFont));
            doc.Add(new Paragraph("• Performance Rating", bodyFont));
        }

        private void AddAdminChapter7_PaymentManagement(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("7. Payment & Refund Management", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Monitor and manage all payment transactions.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Payment Statuses:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Pending: Awaiting confirmation", bodyFont));
            doc.Add(new Paragraph("• Completed: Successfully processed", bodyFont));
            doc.Add(new Paragraph("• Failed: Transaction rejected", bodyFont));
            doc.Add(new Paragraph("• Refunded: Money returned to customer", bodyFont));
        }

        private void AddAdminChapter8_Reports(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("8. Reports & Analytics", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Access comprehensive reports and analytics.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Available Reports:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Daily Booking Report", bodyFont));
            doc.Add(new Paragraph("• Monthly Revenue Report", bodyFont));
            doc.Add(new Paragraph("• Route-wise Analysis", bodyFont));
            doc.Add(new Paragraph("• Bus Utilization Report", bodyFont));
            doc.Add(new Paragraph("• Driver Performance Report", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Export Options: PDF, Excel, CSV", bodyFont));
        }

        private void AddAdminChapter9_SystemSettings(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("9. System Settings", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Configure system-wide settings and preferences.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Available Settings:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Company Information", bodyFont));
            doc.Add(new Paragraph("• Email Configuration", bodyFont));
            doc.Add(new Paragraph("• SMS Settings", bodyFont));
            doc.Add(new Paragraph("• Payment Gateway Settings", bodyFont));
            doc.Add(new Paragraph("• Refund Policy", bodyFont));
            doc.Add(new Paragraph("• Cancellation Policy", bodyFont));
        }

        private void AddAdminChapter10_AuditLogs(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("10. Audit Logs", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("View comprehensive audit trails of all system activities.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Logged Information:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• User actions", bodyFont));
            doc.Add(new Paragraph("• Data modifications", bodyFont));
            doc.Add(new Paragraph("• Login attempts", bodyFont));
            doc.Add(new Paragraph("• IP addresses", bodyFont));
            doc.Add(new Paragraph("• Timestamps", bodyFont));
        }

        #endregion

        #region Driver Chapters

        private void AddDriverChapter1_Introduction(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("1. Introduction for Drivers", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Welcome to the Bus Ticket Management System Driver Portal. This guide will help you manage your assignments and schedules.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Key Features:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• View your assigned schedules", bodyFont));
            doc.Add(new Paragraph("• Track passenger details", bodyFont));
            doc.Add(new Paragraph("• Manage personal information", bodyFont));
            doc.Add(new Paragraph("• View performance ratings", bodyFont));
        }

        private void AddDriverChapter2_ProfileSetup(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("2. Profile Setup", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Complete your driver profile with all required information.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Required Information:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• License Number and Expiry Date", bodyFont));
            doc.Add(new Paragraph("• CNIC (National ID)", bodyFont));
            doc.Add(new Paragraph("• Years of Experience", bodyFont));
            doc.Add(new Paragraph("• Contact Information", bodyFont));
            doc.Add(new Paragraph("• Emergency Contact", bodyFont));
        }

        private void AddDriverChapter3_ViewAssignments(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("3. View Your Assignments", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Check your assigned routes and schedules.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("To view assignments:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("1. Click 'My Schedule'", bodyFont));
            doc.Add(new Paragraph("2. View your daily assignments", bodyFont));
            doc.Add(new Paragraph("3. Click on any assignment for details", bodyFont));
        }

        private void AddDriverChapter4_ManageSchedule(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("4. Manage Your Schedule", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Manage your availability and schedule requests.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Request leave", bodyFont));
            doc.Add(new Paragraph("• View upcoming assignments", bodyFont));
            doc.Add(new Paragraph("• Update availability", bodyFont));
        }

        private void AddDriverChapter5_SafetyGuidelines(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("5. Safety Guidelines", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Follow these safety guidelines for all journeys:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Ensure passenger safety at all times", bodyFont));
            doc.Add(new Paragraph("• Follow traffic rules and regulations", bodyFont));
            doc.Add(new Paragraph("• Maintain vehicle cleanliness", bodyFont));
            doc.Add(new Paragraph("• Report any vehicle issues immediately", bodyFont));
            doc.Add(new Paragraph("• Arrive on time for assigned routes", bodyFont));
        }

        #endregion

        #region Booking Guide Chapters

        private void AddBookingGuideChapter1_GettingStarted(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("1. Getting Started", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("This quick start guide will help you book your first bus ticket in just a few minutes.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Prerequisites:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• Create a user account", bodyFont));
            doc.Add(new Paragraph("• Have a valid email address", bodyFont));
            doc.Add(new Paragraph("• Have a payment method ready", bodyFont));
        }

        private void AddBookingGuideChapter2_SearchingTickets(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("2. Searching for Tickets", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Step 1: Log in to your account", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Step 2: Select 'Book a Ticket'", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Step 3: Enter:", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("• From (Source City)", bodyFont));
            doc.Add(new Paragraph("• To (Destination City)", bodyFont));
            doc.Add(new Paragraph("• Travel Date", bodyFont));
            doc.Add(new Paragraph("Step 4: Click 'Search'", new Font(Font.HELVETICA, 12, Font.BOLD)));
        }

        private void AddBookingGuideChapter3_BookingSteps(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("3. Complete Booking Steps", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Follow these 5 easy steps:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("STEP 1: SELECT YOUR BUS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Click on the bus you prefer from the search results.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("STEP 2: SELECT SEATS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Choose your seat(s) from the interactive bus layout.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("STEP 3: ENTER PASSENGER DETAILS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Fill in passenger name, email, and contact information.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("STEP 4: REVIEW & CONFIRM", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Review your booking details and confirm.", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("STEP 5: PAYMENT", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Complete the payment process using your preferred method.", bodyFont));
        }

        private void AddBookingGuideChapter4_PaymentGuide(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("4. Payment Guide", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("We accept multiple payment methods:", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("💳 CREDIT CARD", new Font(Font.HELVETICA, 11, Font.BOLD)));
            doc.Add(new Paragraph("Visa, MasterCard, American Express", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("💳 DEBIT CARD", new Font(Font.HELVETICA, 11, Font.BOLD)));
            doc.Add(new Paragraph("All major bank debit cards", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("📱 MOBILE WALLET", new Font(Font.HELVETICA, 11, Font.BOLD)));
            doc.Add(new Paragraph("Apple Pay, Google Pay, Samsung Pay", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("🏦 BANK TRANSFER", new Font(Font.HELVETICA, 11, Font.BOLD)));
            doc.Add(new Paragraph("Direct bank-to-bank transfer", bodyFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Security: All payments are encrypted with SSL encryption.", bodyFont));
        }

        private void AddBookingGuideChapter5_CancellationPolicy(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 14, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("5. Cancellation Policy", headingFont);
            heading.SpacingAfter = 12;
            doc.Add(heading);

            doc.Add(new Paragraph("Our flexible cancellation policy:", bodyFont));
            doc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 30, 30, 40 });

            PdfPCell header1 = new PdfPCell(new Phrase("Time Before Journey", new Font(Font.HELVETICA, 11, Font.BOLD)));
            PdfPCell header2 = new PdfPCell(new Phrase("Refund %", new Font(Font.HELVETICA, 11, Font.BOLD)));
            PdfPCell header3 = new PdfPCell(new Phrase("Processing Time", new Font(Font.HELVETICA, 11, Font.BOLD)));
            table.AddCell(header1);
            table.AddCell(header2);
            table.AddCell(header3);

            table.AddCell(new PdfPCell(new Phrase("More than 48 hours", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("100%", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("Instant", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("24-48 hours", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("70%", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("5-7 days", bodyFont)));

            table.AddCell(new PdfPCell(new Phrase("Less than 24 hours", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("0%", bodyFont)));
            table.AddCell(new PdfPCell(new Phrase("N/A", bodyFont)));

            doc.Add(table);
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Note: Cancellation requests must be made through your account before the scheduled departure time.", bodyFont));
        }

        #endregion

        #region Helper Methods

        private void AddScreenshotPlaceholder(Document doc, string screenshotName)
        {
            Font placeholderFont = new Font(Font.HELVETICA, 10, Font.ITALIC);
            Paragraph p = new Paragraph($"[SCREENSHOT-{screenshotName}]", placeholderFont);
            p.Alignment = Element.ALIGN_CENTER;
            p.BackgroundColor = new Color(230, 230, 230);
            p.SpacingBefore = 10;
            p.SpacingAfter = 10;
            doc.Add(p);
        }

        #endregion
    }
}
