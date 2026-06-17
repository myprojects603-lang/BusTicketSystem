using System.Threading.Tasks;
using BusTicketManagementSystem.Reporting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketManagementSystem.API.Controllers
{
    /// <summary>
    /// API endpoints for generating and downloading documentation.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentationController : ControllerBase
    {
        private readonly IUserManualService _userManualService;

        public DocumentationController(IUserManualService userManualService)
        {
            _userManualService = userManualService;
        }

        /// <summary>
        /// Generate and download customer user manual PDF.
        /// </summary>
        [HttpGet("user-manual/pdf")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserManualPdf()
        {
            try
            {
                var pdfBytes = await _userManualService.GenerateUserManualPdfAsync();
                return File(pdfBytes, "application/pdf", "BusTicketSystem_UserManual.pdf");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error generating PDF", error = ex.Message });
            }
        }

        /// <summary>
        /// Generate and download admin manual PDF.
        /// </summary>
        [HttpGet("admin-manual/pdf")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminManualPdf()
        {
            try
            {
                var pdfBytes = await _userManualService.GenerateAdminManualPdfAsync();
                return File(pdfBytes, "application/pdf", "BusTicketSystem_AdminManual.pdf");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error generating PDF", error = ex.Message });
            }
        }

        /// <summary>
        /// Generate and download driver manual PDF.
        /// </summary>
        [HttpGet("driver-manual/pdf")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> GetDriverManualPdf()
        {
            try
            {
                var pdfBytes = await _userManualService.GenerateDriverManualPdfAsync();
                return File(pdfBytes, "application/pdf", "BusTicketSystem_DriverManual.pdf");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error generating PDF", error = ex.Message });
            }
        }

        /// <summary>
        /// Generate and download quick booking guide PDF.
        /// </summary>
        [HttpGet("booking-guide/pdf")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookingGuidePdf()
        {
            try
            {
                var pdfBytes = await _userManualService.GenerateBookingGuidePdfAsync();
                return File(pdfBytes, "application/pdf", "BusTicketSystem_BookingGuide.pdf");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error generating PDF", error = ex.Message });
            }
        }
    }
}
