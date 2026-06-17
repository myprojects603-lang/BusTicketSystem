using System;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BusTicketManagementSystem.Reporting.Services
{
    /// <summary>
    /// Enhanced service for generating comprehensive user manual PDF documents with screenshots.
    /// </summary>
    public class EnhancedUserManualService : IUserManualService
    {
        public async Task<byte[]> GenerateUserManualWithScreenshotsPdfAsync()
        {
            return await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    // Cover Page
                    AddCoverPage(doc);

                    // Table of Contents
                    doc.NewPage();
                    AddDetailedTableOfContents(doc);

                    // Quick Start Guide
                    doc.NewPage();
                    AddQuickStartSection(doc);

                    // Detailed Chapters
                    doc.NewPage();
                    AddDetailedChapter1(doc);
                    doc.NewPage();
                    AddDetailedChapter2(doc);
                    doc.NewPage();
                    AddDetailedChapter3(doc);
                    doc.NewPage();
                    AddDetailedChapter4(doc);
                    doc.NewPage();
                    AddDetailedChapter5(doc);
                    doc.NewPage();
                    AddDetailedChapter6(doc);
                    doc.NewPage();
                    AddDetailedChapter7(doc);
                    doc.NewPage();
                    AddDetailedChapter8(doc);
                    doc.NewPage();
                    AddDetailedChapter9(doc);
                    doc.NewPage();
                    AddDetailedChapter10(doc);

                    // Troubleshooting
                    doc.NewPage();
                    AddTroubleshootingSection(doc);

                    // Appendix
                    doc.NewPage();
                    AddAppendix(doc);

                    // Back Cover
                    doc.NewPage();
                    AddBackCover(doc);

                    doc.Close();
                    return ms.ToArray();
                }
            });
        }

        private void AddCoverPage(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 48, Font.BOLD, new Color(52, 73, 94));
            Font subtitleFont = new Font(Font.HELVETICA, 24, Font.NORMAL, new Color(100, 100, 100));
            Font versionFont = new Font(Font.HELVETICA, 14, Font.ITALIC, new Color(150, 150, 150));

            // Add some space
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph title = new Paragraph("BUS TICKET", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 0;
            doc.Add(title);

            Paragraph title2 = new Paragraph("MANAGEMENT SYSTEM", titleFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 20;
            doc.Add(title2);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph subtitle = new Paragraph("Customer User Manual & Quick Start Guide", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            subtitle.SpacingAfter = 50;
            doc.Add(subtitle);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph version = new Paragraph("Version 1.0", versionFont);
            version.Alignment = Element.ALIGN_CENTER;
            doc.Add(version);

            Paragraph date = new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy}", versionFont);
            date.Alignment = Element.ALIGN_CENTER;
            doc.Add(date);

            Paragraph contact = new Paragraph("support@busticketmanagementsystem.com", versionFont);
            contact.Alignment = Element.ALIGN_CENTER;
            doc.Add(contact);
        }

        private void AddDetailedTableOfContents(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 18, Font.BOLD, new Color(52, 73, 94));
            Font contentFont = new Font(Font.HELVETICA, 12, Font.NORMAL);

            Paragraph heading = new Paragraph("TABLE OF CONTENTS", headingFont);
            heading.Alignment = Element.ALIGN_CENTER;
            heading.SpacingAfter = 30;
            doc.Add(heading);

            string[][] chapters = new[]
            {
                new[] { "Quick Start Guide", "3" },
                new[] { "1. System Overview & Requirements", "4" },
                new[] { "2. Creating Your Account", "5" },
                new[] { "3. Login & Security", "6" },
                new[] { "4. Dashboard Tour", "7" },
                new[] { "5. Searching for Buses", "8" },
                new[] { "6. Complete Booking Process", "9" },
                new[] { "7. Seat Selection Guide", "10" },
                new[] { "8. Payment Methods & Security", "11" },
                new[] { "9. Managing Your Bookings", "12" },
                new[] { "10. Cancellation & Refunds", "13" },
                new[] { "Troubleshooting & Support", "14" },
                new[] { "Appendix & FAQ", "15" }
            };

            foreach (var chapter in chapters)
            {
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 85, 15 });
                table.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell cell1 = new PdfPCell(new Phrase(chapter[0], contentFont));
                PdfPCell cell2 = new PdfPCell(new Phrase(chapter[1], contentFont));
                cell1.Border = Rectangle.NO_BORDER;
                cell2.Border = Rectangle.NO_BORDER;
                cell2.HorizontalAlignment = Element.ALIGN_RIGHT;

                table.AddCell(cell1);
                table.AddCell(cell2);

                Paragraph p = new Paragraph();
                p.Add(table);
                p.SpacingAfter = 8;
                doc.Add(p);
            }
        }

        private void AddQuickStartSection(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);
            Font boldFont = new Font(Font.HELVETICA, 11, Font.BOLD);

            Paragraph title = new Paragraph("QUICK START GUIDE", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20;
            doc.Add(title);

            doc.Add(new Paragraph("Book Your First Ticket in 5 Minutes", boldFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 1: CREATE ACCOUNT", boldFont));
            doc.Add(new Paragraph("Visit www.busticketmanagementsystem.com → Click 'Sign Up' → Enter email & password → Verify email", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "REGISTRATION_SCREEN");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 2: LOGIN", boldFont));
            doc.Add(new Paragraph("Enter your username and password → Click 'Login' → You're in!", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "LOGIN_SCREEN");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 3: SEARCH BUSES", boldFont));
            doc.Add(new Paragraph("Select From City → Select To City → Pick Date → Click 'Search'", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "SEARCH_SCREEN");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 4: SELECT & BOOK", boldFont));
            doc.Add(new Paragraph("Choose your bus → Select seats → Enter passenger details → Review & Confirm", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "BOOKING_SCREEN");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 5: PAYMENT", boldFont));
            doc.Add(new Paragraph("Choose payment method → Enter details → Complete payment → Get confirmation!", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "PAYMENT_SCREEN");
        }

        private void AddDetailedChapter1(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("1. SYSTEM OVERVIEW & REQUIREMENTS", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("What is the Bus Ticket Management System?", sectionFont));
            doc.Add(new Paragraph("A modern, user-friendly platform for booking bus tickets online. Easy search, secure payment, instant confirmation.", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("System Requirements", sectionFont));
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            AddTableHeader(table, "Item", "Requirement");
            AddTableRow(table, "Browser", "Chrome, Firefox, Safari, Edge (Latest version)");
            AddTableRow(table, "Internet", "Minimum 2 Mbps");
            AddTableRow(table, "Device", "Desktop, Laptop, Tablet, or Smartphone");
            AddTableRow(table, "JavaScript", "Must be Enabled");
            AddTableRow(table, "Cookies", "Must be Enabled");
            doc.Add(table);
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Key Features", sectionFont));
            doc.Add(new Paragraph("✓ Real-time seat availability", bodyFont));
            doc.Add(new Paragraph("✓ Multiple payment options", bodyFont));
            doc.Add(new Paragraph("✓ Instant booking confirmation", bodyFont));
            doc.Add(new Paragraph("✓ 24-hour cancellation policy", bodyFont));
            doc.Add(new Paragraph("✓ Email & SMS notifications", bodyFont));
            doc.Add(new Paragraph("✓ Secure SSL encryption", bodyFont));
        }

        private void AddDetailedChapter2(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("2. CREATING YOUR ACCOUNT", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Step-by-Step Registration", sectionFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("1. Click 'Sign Up' on the home page", bodyFont));
            doc.Add(new Paragraph("2. Enter your email address", bodyFont));
            doc.Add(new Paragraph("3. Create a strong password (min. 8 characters)", bodyFont));
            doc.Add(new Paragraph("4. Enter your first and last name", bodyFont));
            doc.Add(new Paragraph("5. Enter your phone number (optional)", bodyFont));
            doc.Add(new Paragraph("6. Accept terms and conditions", bodyFont));
            doc.Add(new Paragraph("7. Click 'Create Account'", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "REGISTRATION_FORM");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Email Verification", sectionFont));
            doc.Add(new Paragraph("You'll receive a verification email. Click the link to verify your email address and activate your account.", bodyFont));
        }

        private void AddDetailedChapter3(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("3. LOGIN & SECURITY", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Logging In", sectionFont));
            doc.Add(new Paragraph("1. Go to www.busticketmanagementsystem.com", bodyFont));
            doc.Add(new Paragraph("2. Click 'Login'", bodyFont));
            doc.Add(new Paragraph("3. Enter your email/username", bodyFont));
            doc.Add(new Paragraph("4. Enter your password", bodyFont));
            doc.Add(new Paragraph("5. Click 'Sign In'", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "LOGIN_PAGE");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Two-Factor Authentication (2FA)", sectionFont));
            doc.Add(new Paragraph("If enabled, you'll receive an OTP (one-time password) via email or SMS.", bodyFont));
            doc.Add(new Paragraph("Enter this 6-digit code to complete login.", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Password Security Tips", sectionFont));
            doc.Add(new Paragraph("• Use at least 8 characters", bodyFont));
            doc.Add(new Paragraph("• Mix uppercase and lowercase letters", bodyFont));
            doc.Add(new Paragraph("• Include numbers and special characters", bodyFont));
            doc.Add(new Paragraph("• Never share your password", bodyFont));
            doc.Add(new Paragraph("• Change password regularly", bodyFont));
        }

        private void AddDetailedChapter4(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("4. DASHBOARD TOUR", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Main Dashboard", sectionFont));
            AddScreenshotBox(doc, "MAIN_DASHBOARD");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Dashboard Sections", sectionFont));
            doc.Add(new Paragraph("Header: Profile name, logout, settings", bodyFont));
            doc.Add(new Paragraph("Quick Search: Find buses immediately", bodyFont));
            doc.Add(new Paragraph("Recent Bookings: Last 5 bookings with status", bodyFont));
            doc.Add(new Paragraph("Notifications: Updates and alerts", bodyFont));
            doc.Add(new Paragraph("My Account: Profile and preferences", bodyFont));
        }

        private void AddDetailedChapter5(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("5. SEARCHING FOR BUSES", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Search Steps", sectionFont));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("1. Select 'From' city (origin)", bodyFont));
            doc.Add(new Paragraph("2. Select 'To' city (destination)", bodyFont));
            doc.Add(new Paragraph("3. Choose travel date", bodyFont));
            doc.Add(new Paragraph("4. Click 'Search Buses'", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "SEARCH_RESULTS");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Filtering Results", sectionFont));
            doc.Add(new Paragraph("• Sort by Price (Low to High / High to Low)", bodyFont));
            doc.Add(new Paragraph("• Filter by Bus Type (Luxury, Standard, Economy)", bodyFont));
            doc.Add(new Paragraph("• Filter by Departure Time", bodyFont));
            doc.Add(new Paragraph("• View bus ratings and reviews", bodyFont));
        }

        private void AddDetailedChapter6(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("6. COMPLETE BOOKING PROCESS", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("The 5-Step Booking Wizard", sectionFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 1: SELECT BUS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Click on your preferred bus from search results.", bodyFont));
            AddScreenshotBox(doc, "SELECT_BUS");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 2: SELECT SEATS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Choose your seats from the interactive bus layout.", bodyFont));
            AddScreenshotBox(doc, "SELECT_SEATS");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 3: PASSENGER DETAILS", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Enter names and contact info for all passengers.", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 4: REVIEW BOOKING", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Check all details before confirming.", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("STEP 5: PAYMENT", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Choose payment method and complete transaction.", bodyFont));
        }

        private void AddDetailedChapter7(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("7. SEAT SELECTION GUIDE", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Understanding the Seat Map", sectionFont));
            AddScreenshotBox(doc, "SEAT_MAP");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Seat Colors", sectionFont));
            doc.Add(new Paragraph("🟩 Green = Available", bodyFont));
            doc.Add(new Paragraph("🟥 Red = Already Booked", bodyFont));
            doc.Add(new Paragraph("🟦 Blue = Your Selection", bodyFont));
            doc.Add(new Paragraph("⬜ Grey = Not Available", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Selecting Seats", sectionFont));
            doc.Add(new Paragraph("1. Click on any green seat", bodyFont));
            doc.Add(new Paragraph("2. Seat turns blue", bodyFont));
            doc.Add(new Paragraph("3. Price updates automatically", bodyFont));
            doc.Add(new Paragraph("4. Click again to deselect", bodyFont));
        }

        private void AddDetailedChapter8(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("8. PAYMENT METHODS & SECURITY", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Accepted Payment Methods", sectionFont));
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            AddTableHeader(table, "Payment Method", "Details");
            AddTableRow(table, "💳 Credit Card", "Visa, MasterCard, Amex");
            AddTableRow(table, "💳 Debit Card", "All major banks");
            AddTableRow(table, "📱 Mobile Wallet", "Apple Pay, Google Pay");
            AddTableRow(table, "🏦 Bank Transfer", "Direct transfer available");
            doc.Add(table);
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("Payment Security", sectionFont));
            doc.Add(new Paragraph("✓ SSL 256-bit encryption", bodyFont));
            doc.Add(new Paragraph("✓ PCI DSS compliant", bodyFont));
            doc.Add(new Paragraph("✓ No card details stored", bodyFont));
            doc.Add(new Paragraph("✓ 3D Secure authentication", bodyFont));
            doc.Add(new Paragraph("✓ Fraud protection", bodyFont));
        }

        private void AddDetailedChapter9(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("9. MANAGING YOUR BOOKINGS", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("View Your Bookings", sectionFont));
            doc.Add(new Paragraph("1. Click 'My Bookings' in menu", bodyFont));
            doc.Add(new Paragraph("2. See all past and upcoming bookings", bodyFont));
            doc.Add(new Paragraph("3. Click on any booking for details", bodyFont));
            doc.Add(new Paragraph(" "));
            AddScreenshotBox(doc, "MY_BOOKINGS");
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("For Each Booking You Can", sectionFont));
            doc.Add(new Paragraph("• View full details", bodyFont));
            doc.Add(new Paragraph("• Download e-ticket", bodyFont));
            doc.Add(new Paragraph("• Check payment status", bodyFont));
            doc.Add(new Paragraph("• Cancel (if eligible)", bodyFont));
            doc.Add(new Paragraph("• Share with others", bodyFont));
        }

        private void AddDetailedChapter10(Document doc)
        {
            Font chapterFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font sectionFont = new Font(Font.HELVETICA, 13, Font.BOLD);
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph chapter = new Paragraph("10. CANCELLATION & REFUNDS", chapterFont);
            chapter.SpacingAfter = 15;
            doc.Add(chapter);

            doc.Add(new Paragraph("Cancellation Policy", sectionFont));
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            AddTableHeader(table, "Time Before Journey", "Refund %", "Processing Time");
            AddTableRow(table, "> 48 hours", "100%", "Instant");
            AddTableRow(table, "24-48 hours", "70%", "5-7 days");
            AddTableRow(table, "< 24 hours", "0%", "N/A");
            doc.Add(table);
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("How to Cancel", sectionFont));
            doc.Add(new Paragraph("1. Go to 'My Bookings'", bodyFont));
            doc.Add(new Paragraph("2. Find the booking", bodyFont));
            doc.Add(new Paragraph("3. Click 'Cancel Booking'", bodyFont));
            doc.Add(new Paragraph("4. Confirm cancellation", bodyFont));
            doc.Add(new Paragraph("5. Refund initiated", bodyFont));
        }

        private void AddTroubleshootingSection(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font qaFont = new Font(Font.HELVETICA, 11, Font.BOLD);
            Font ansFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("TROUBLESHOOTING & SUPPORT", headingFont);
            heading.SpacingAfter = 20;
            doc.Add(heading);

            doc.Add(new Paragraph("Common Issues & Solutions", new Font(Font.HELVETICA, 13, Font.BOLD)));
            doc.Add(new Paragraph(" "));

            AddFAQItem(doc, "Q: I forgot my password. What should I do?", "A: Click 'Forgot Password' on login page. Enter your email and follow the instructions sent to your inbox.");
            AddFAQItem(doc, "Q: How long does it take to receive my confirmation?", "A: Instant! You'll see a confirmation message immediately and receive an email within seconds.");
            AddFAQItem(doc, "Q: Can I change my booking after confirming?", "A: No, you cannot modify. Cancel and create a new booking instead.");
            AddFAQItem(doc, "Q: How do I know if my payment went through?", "A: Check your 'My Bookings' section or look for confirmation email.");
            AddFAQItem(doc, "Q: Is my payment information safe?", "A: Yes! We use military-grade SSL encryption. Your card details are never stored.");
            AddFAQItem(doc, "Q: When will I receive my refund?", "A: Within 5-7 business days depending on your bank.");
            AddFAQItem(doc, "Q: How do I contact customer support?", "A: Email: support@busticket.com | Phone: +1-800-XXX-XXXX | Live Chat: Available 24/7");
            AddFAQItem(doc, "Q: Can multiple people use one account?", "A: No, one account per person. But you can book for others by entering their details.");
            AddFAQItem(doc, "Q: Is there a cancellation fee?", "A: Only a percentage deduction based on time before journey (see cancellation policy).");
            AddFAQItem(doc, "Q: Can I get a paper ticket?", "A: E-tickets are digital. You can print them from the app or email.");
        }

        private void AddAppendix(Document doc)
        {
            Font headingFont = new Font(Font.HELVETICA, 16, Font.BOLD, new Color(52, 73, 94));
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph heading = new Paragraph("APPENDIX", headingFont);
            heading.SpacingAfter = 20;
            doc.Add(heading);

            doc.Add(new Paragraph("A. Glossary of Terms", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Booking Reference: Unique ID for your reservation", bodyFont));
            doc.Add(new Paragraph("• E-Ticket: Digital version of your ticket", bodyFont));
            doc.Add(new Paragraph("• Seat Number: Your assigned seat in the bus", bodyFont));
            doc.Add(new Paragraph("• Passenger: Person traveling on the bus", bodyFont));
            doc.Add(new Paragraph("• Route: Journey from source to destination city", bodyFont));
            doc.Add(new Paragraph("• Schedule: Timetable of bus departures", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("B. Contact Information", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Email: support@busticketmanagementsystem.com", bodyFont));
            doc.Add(new Paragraph("Phone: +1-800-BUS-TICKET (1-800-287-8425)", bodyFont));
            doc.Add(new Paragraph("Website: www.busticketmanagementsystem.com", bodyFont));
            doc.Add(new Paragraph("Live Chat: Available 24/7 on website", bodyFont));
            doc.Add(new Paragraph("Facebook: @BusTicketManagementSystem", bodyFont));
            doc.Add(new Paragraph("Twitter: @BusTicketMgmt", bodyFont));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("C. Keyboard Shortcuts", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("• Ctrl+B: Go to Book Ticket page", bodyFont));
            doc.Add(new Paragraph("• Ctrl+M: Go to My Bookings", bodyFont));
            doc.Add(new Paragraph("• Ctrl+L: Logout", bodyFont));
            doc.Add(new Paragraph("• Ctrl+H: Go to Home", bodyFont));
        }

        private void AddBackCover(Document doc)
        {
            Font titleFont = new Font(Font.HELVETICA, 24, Font.BOLD, new Color(52, 73, 94));
            Font bodyFont = new Font(Font.HELVETICA, 12, Font.NORMAL);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph title = new Paragraph("Thank You for Choosing Us!", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Paragraph tagline = new Paragraph("Your Journey, Our Priority", new Font(Font.HELVETICA, 16, Font.ITALIC));
            tagline.Alignment = Element.ALIGN_CENTER;
            doc.Add(tagline);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph("For questions or feedback:", bodyFont));
            doc.Add(new Paragraph("support@busticketmanagementsystem.com", new Font(Font.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph($"Version 1.0 | Generated {DateTime.Now:MMMM yyyy}", bodyFont));
            doc.Add(new Paragraph("© 2026 Bus Ticket Management System. All Rights Reserved.", bodyFont));
        }

        private void AddFAQItem(Document doc, string question, string answer)
        {
            Font qaFont = new Font(Font.HELVETICA, 11, Font.BOLD);
            Font ansFont = new Font(Font.HELVETICA, 11, Font.NORMAL);

            Paragraph q = new Paragraph(question, qaFont);
            q.SpacingBefore = 10;
            q.SpacingAfter = 4;
            doc.Add(q);

            Paragraph a = new Paragraph(answer, ansFont);
            a.SpacingAfter = 10;
            doc.Add(a);
        }

        private void AddScreenshotBox(Document doc, string label)
        {
            BaseColor color = new Color(240, 240, 240);
            Font labelFont = new Font(Font.HELVETICA, 10, Font.ITALIC, new Color(100, 100, 100));

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase($"[SCREENSHOT: {label}]", labelFont));
            cell.BackgroundColor = color;
            cell.Padding = 40;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            doc.Add(table);
        }

        private void AddTableHeader(PdfPTable table, params string[] headers)
        {
            Font headerFont = new Font(Font.HELVETICA, 11, Font.BOLD, new Color(255, 255, 255));
            foreach (var header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                cell.BackgroundColor = new Color(52, 73, 94);
                cell.Padding = 8;
                table.AddCell(cell);
            }
        }

        private void AddTableRow(PdfPTable table, params string[] values)
        {
            Font bodyFont = new Font(Font.HELVETICA, 11, Font.NORMAL);
            foreach (var value in values)
            {
                PdfPCell cell = new PdfPCell(new Phrase(value, bodyFont));
                cell.Padding = 6;
                table.AddCell(cell);
            }
        }

        // Implement interface methods (delegating to existing implementation)
        public async Task<byte[]> GenerateUserManualPdfAsync()
            => await GenerateUserManualWithScreenshotsPdfAsync();

        public async Task<byte[]> GenerateAdminManualPdfAsync()
            => await Task.FromResult(new byte[0]); // Placeholder

        public async Task<byte[]> GenerateDriverManualPdfAsync()
            => await Task.FromResult(new byte[0]); // Placeholder

        public async Task<byte[]> GenerateBookingGuidePdfAsync()
            => await Task.FromResult(new byte[0]); // Placeholder
    }
}
