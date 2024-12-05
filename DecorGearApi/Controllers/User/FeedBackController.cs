using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [ApiController]
    [Route("api/user/[controller]")]

    public class FeedBackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;

        public FeedBackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }


        [HttpPost("create")]
        public async Task<ActionResult> CreateFeedBack([FromBody] CreateFeedBackRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _feedbackServices.CreateFeedBack(request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> Getbyid(int id, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackServices.FeedBackById(id, cancellationToken);
            if (feedbacks == null)
            {
                return NotFound("FeedBack không tồn tại");
            }
            return Ok(feedbacks);
        }


        [HttpPut("update")]
        public async Task<ActionResult> UpdateFeedBack(int id, [FromBody] UpdateFeedBackRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _feedbackServices.UpdateFeedBack(id, request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }
    }
}
