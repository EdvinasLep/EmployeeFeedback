namespace EmployeeFeedback.DTOs
{
    public class FeedbackSummaryDto
    {
        public string Department { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public int TotalFeedbackCount { get; set; }
    }
} 