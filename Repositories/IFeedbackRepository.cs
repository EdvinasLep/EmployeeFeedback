using EmployeeFeedback.Models;

namespace EmployeeFeedback.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Feedback> CreateAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<IEnumerable<Feedback>> GetByDepartmentAsync(string department);
        Task<(double averageRating, int totalCount)> GetDepartmentSummaryAsync(string department);
    }
} 