using AutoMapper;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearApplication.IServices;
using Ecommerce.Application.DataTransferObj.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public AccountController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userServices.GetAllUsers(cancellationToken);
            return Ok(new
            {
                TotalUsers = users.Count,
                Users = users
            });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.UpdateUser(id, request, cancellationToken);

            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }

            return StatusCode(result.Status, result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            var result = await _userServices.DeleteUser(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return NotFound("User not found.");
        }
    }
}

