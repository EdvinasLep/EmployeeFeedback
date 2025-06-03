using EmployeeFeedback.DTOs;

namespace EmployeeFeedback.Services
{
    public interface IFeedbackService
    {
        Task<FeedbackResponseDto> CreateFeedbackAsync(CreateFeedbackDto createFeedbackDto);
        Task<IEnumerable<FeedbackResponseDto>> GetAllFeedbackAsync();
        Task<FeedbackSummaryDto> GetDepartmentSummaryAsync(string department);
    }
} 