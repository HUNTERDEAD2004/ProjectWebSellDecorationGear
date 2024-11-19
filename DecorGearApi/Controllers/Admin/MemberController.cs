using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.Interface;
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
        private readonly IMemberRespository _memberRespository;

        public MemberController(IMemberRespository memberRespository)
        {
            _memberRespository = memberRespository;
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateMember([FromBody] CreateMemberRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _memberRespository.CreateMemberAsync(request, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllMembers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var members = await _memberRespository.GetAllMembersAsync(pageNumber, pageSize);
            return Ok(members);
        }


        [HttpPut("update")]
        public async Task<ActionResult> UpdateMember(int id, [FromBody] UpdateMemberRequest request, CancellationToken cancellation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _memberRespository.UpdateMemberAsync(id, request, cancellation);
            return StatusCode(result.Status, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> GetMemberbyid(int id, CancellationToken cancellationToken)
        {
            var member = await _memberRespository.GetMemberByIdAsync(id, cancellationToken);
            if (member == null)
            {
                return NotFound("Member không tồn tại");
            }
            return Ok(member);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteMember(int id, CancellationToken cancellationToken)
        {
            var result = await _memberRespository.DeleteMemberAsync(new DeleteMemberRequest { MemberID = id }, cancellationToken);
            return StatusCode(result.Status, result.Message);
        }

    }
}
