using EmployeeFeedback.DTOs;
using EmployeeFeedback.Models;
using EmployeeFeedback.Repositories;

namespace EmployeeFeedback.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackResponseDto> CreateFeedbackAsync(CreateFeedbackDto createFeedbackDto)
        {
            if (string.IsNullOrWhiteSpace(createFeedbackDto.Department))
                throw new ArgumentException("Department cannot be empty", nameof(createFeedbackDto.Department));

            if (createFeedbackDto.Rating < 1 || createFeedbackDto.Rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5", nameof(createFeedbackDto.Rating));

            var feedback = new Feedback
            {
                Text = createFeedbackDto.Text?.Trim(),
                Rating = createFeedbackDto.Rating,
                Department = createFeedbackDto.Department.Trim()
            };

            var createdFeedback = await _feedbackRepository.CreateAsync(feedback);

            return MapToResponseDto(createdFeedback);
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetAllFeedbackAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return feedbacks.Select(MapToResponseDto);
        }

        public async Task<FeedbackSummaryDto> GetDepartmentSummaryAsync(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("Department cannot be empty", nameof(department));

            var (averageRating, totalCount) = await _feedbackRepository.GetDepartmentSummaryAsync(department);

            return new FeedbackSummaryDto
            {
                Department = department,
                AverageRating = averageRating,
                TotalFeedbackCount = totalCount
            };
        }

        private static FeedbackResponseDto MapToResponseDto(Feedback feedback)
        {
            return new FeedbackResponseDto
            {
                Id = feedback.Id,
                Text = feedback.Text,
                Rating = feedback.Rating,
                Department = feedback.Department,
                CreatedAt = feedback.CreatedAt
            };
        }
    }
} 