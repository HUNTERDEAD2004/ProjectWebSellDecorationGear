using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberServices _memberServices;

        public MemberController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateMember([FromBody] CreateMemberRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _memberServices.CreateMemberAsync(request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }


        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> GetMemberbyid(int id, CancellationToken cancellationToken)
        {
            var member = await _memberServices.GetMemberByIdAsync(id, cancellationToken);
            if (member == null)
            {
                return NotFound("Member không tồn tại");
            }
            return Ok(member);
        }


       
    }
}
