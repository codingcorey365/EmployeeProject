namespace EmployeeProject.Models
{
    // Model for handling error information in the application
    public class ErrorViewModel
    {
        // Property to store the unique request ID for error tracking
        public string? RequestId { get; set; }

        // Property to determine if the RequestId should be shown
        // Returns true if RequestId is not null or empty, otherwise false
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}