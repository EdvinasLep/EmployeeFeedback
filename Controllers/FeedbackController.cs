using Microsoft.AspNetCore.Mvc;
using EmployeeFeedback.DTOs;
using EmployeeFeedback.Services;

namespace EmployeeFeedback.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackResponseDto>> CreateFeedback(CreateFeedbackDto createFeedbackDto)
        {
            try
            {
                var result = await _feedbackService.CreateFeedbackAsync(createFeedbackDto);
                return CreatedAtAction(nameof(CreateFeedback), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while creating feedback", details = ex.Message });
            }
        }

        [HttpGet("summary")]
        public async Task<ActionResult<FeedbackSummaryDto>> GetDepartmentSummary([FromQuery] string department)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(department))
                {
                    return BadRequest(new { error = "Department parameter is required" });
                }

                var result = await _feedbackService.GetDepartmentSummaryAsync(department);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while retrieving summary", details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackResponseDto>>> GetAllFeedback()
        {
            try
            {
                var result = await _feedbackService.GetAllFeedbackAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while retrieving feedback", details = ex.Message });
            }
        }
    }
} 