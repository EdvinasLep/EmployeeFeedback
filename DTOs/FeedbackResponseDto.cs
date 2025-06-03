namespace EmployeeFeedback.DTOs
{
    public class FeedbackResponseDto
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public int Rating { get; set; }
        public string Department { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
} 