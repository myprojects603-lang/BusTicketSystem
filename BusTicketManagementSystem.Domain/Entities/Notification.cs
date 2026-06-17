using System;
using System.Collections.Generic;

namespace BusTicketManagementSystem.Domain.Entities
{
    /// <summary>
    /// Represents a system notification sent to users.
    /// Supports Email, SMS, and In-App notifications.
    /// </summary>
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Email, SMS, InApp
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? RecipientEmail { get; set; }
        public string? RecipientPhone { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Sent, Failed
        public int? RetryCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? SentAt { get; set; }
        public DateTime? FailedAt { get; set; }
        public string? ErrorMessage { get; set; }

        // Navigation Properties
        public virtual AspNetUser? User { get; set; }
    }
}
