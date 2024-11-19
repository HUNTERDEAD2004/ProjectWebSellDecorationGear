using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
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
        private readonly IFeedBackRespository _feedBackRespository;

        public FeedBackController(IFeedBackRespository feedBackRespository)
        {
            _feedBackRespository = feedBackRespository;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var feedbacks = await _feedBackRespository.GetAllFeedBack(pageNumber, pageSize);
            return Ok(feedbacks);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateFeedBack(int id, [FromBody] UpdateFeedBackRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _feedBackRespository.UpdateFeedBack(id, request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> Getbyid(int id, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedBackRespository.FeedBackById(id, cancellationToken);
            if (feedbacks == null)
            {
                return NotFound("FeedBack không tồn tại");
            }
            return Ok(feedbacks);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteFeedBack(int id, CancellationToken cancellationToken)
        {
            var result = await _feedBackRespository.DeleteFeedBack(new DeleteFeedBackRequest { FeedBackID = id }, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }
    }
}

