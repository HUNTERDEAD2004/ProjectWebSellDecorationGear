using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("get-by-id/{id}")]

        public async Task<ActionResult> Getbyid(int id, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackServices.FeedBackById(id,cancellationToken);
            if (feedbacks == null)
            {
                return NotFound("FeedBack không tồn tại");
            }
            return Ok(feedbacks);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateFeedBack([FromBody]CreateFeedBackRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) 
            { 
              return BadRequest(ModelState);
            }
            var result = await _feedbackServices.CreateFeedBack(request,cancellationToken);
            return StatusCode(result.Status,result.Message);
        } 

        [HttpPut("update")]

        public async Task<ActionResult> UpdateFeedback([FromBody]UpdateFeedBackRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _feedbackServices.UpdateFeedBack(request, cancellationToken);
            return StatusCode(result.Status,result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteFeedBack(DeleteFeedBackRequest request, CancellationToken cancellationToken)
        {
            var result = await _feedbackServices.DeleteFeedBack(request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }
    }
}
