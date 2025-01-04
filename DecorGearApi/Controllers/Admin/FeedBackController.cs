using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;

        public FeedBackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackServices.GetAllFeedBack(cancellationToken);
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

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteFeedBack(int id, CancellationToken cancellationToken)
        {
            var result = await _feedbackServices.DeleteFeedBack(id, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }
    }
}

