using System.ComponentModel.DataAnnotations;

namespace EmployeeFeedback.DTOs
{
    public class CreateFeedbackDto
    {
        [StringLength(1000)]
        public string? Text { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Required]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;
    }
} 