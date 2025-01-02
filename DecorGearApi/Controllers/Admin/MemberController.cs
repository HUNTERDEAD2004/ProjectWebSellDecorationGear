using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.Admin
{

    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
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

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var Member = await _memberServices.GetAllMembersAsync(cancellationToken);
            return Ok(Member);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateMember(int id, [FromBody] UpdateMemberRequest request, CancellationToken cancellation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _memberServices.UpdateMemberAsync(id, request, cancellation);
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


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteMember(int id, CancellationToken cancellationToken)
        {
            var result = await _memberServices.DeleteMemberAsync(id, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }

    }
}
