using Microsoft.EntityFrameworkCore;
using EmployeeFeedback.Data;
using EmployeeFeedback.Models;

namespace EmployeeFeedback.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackContext _context;

        public FeedbackRepository(FeedbackContext context)
        {
            _context = context;
        }

        public async Task<Feedback> CreateAsync(Feedback feedback)
        {
            feedback.Id = Guid.NewGuid();
            feedback.CreatedAt = DateTime.UtcNow;
            
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            
            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByDepartmentAsync(string department)
        {
            return await _context.Feedbacks
                .Where(f => f.Department.ToLower() == department.ToLower())
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<(double averageRating, int totalCount)> GetDepartmentSummaryAsync(string department)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.Department.ToLower() == department.ToLower())
                .Select(f => f.Rating)
                .ToListAsync();

            if (!feedbacks.Any())
                return (0, 0);

            var averageRating = feedbacks.Average();
            var totalCount = feedbacks.Count;

            return (Math.Round(averageRating, 1), totalCount);
        }
    }
} 