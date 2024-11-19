using AutoMapper;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRespository _userRespository;
        private readonly IMapper _mapper;

        public AccountController(IUserRespository userRespository, IMapper mapper)
        {
            _userRespository = userRespository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var users = await _userRespository.GetAllUsers(pageNumber, pageSize);
            return Ok(users);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRespository.UpdateUser(id, request, cancellationToken);

            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }

            return StatusCode(result.Status, result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRespository.DeleteUser(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return NotFound("User not found.");
        }
    }
}

