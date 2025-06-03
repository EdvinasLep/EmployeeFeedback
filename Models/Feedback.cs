using System.ComponentModel.DataAnnotations;

namespace EmployeeFeedback.Models
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(1000)]
        public string? Text { get; set; }

        [Range(1, 5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }
    }
} 