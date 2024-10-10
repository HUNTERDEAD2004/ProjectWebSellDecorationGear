using AutoMapper;
using DecorGearApplication.IServices;
using Ecommerce.Application.DataTransferObj.User.Request;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DecorGearApi.Controllers.User
{
    [ApiController]
    [Route("api/user/[controller]")]
    
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public AccountController(IUserServices userServices, IMapper mapper, ITokenServices tokenServices)
        {
            _userServices = userServices;
            _mapper = mapper;
            _tokenServices = tokenServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateRequest request, CancellationToken cancellationToken)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.Register(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }

            return StatusCode(result.Status, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserById(id, cancellationToken);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Người dùng chỉ có thể xem thông tin của chính mình
            if (currentUserId == id.ToString())
            {
                var limitedUserInfo = new
                {
                    user.UserName,
                    user.Email,
                    user.Name,
                    user.PhoneNumber
                };
                return Ok(limitedUserInfo);
            }
            return Ok(user);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra xem người dùng có quyền cập nhật thông tin cá nhân không
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId != id.ToString())
            {
                return Forbid(); // Người dùng không có quyền cập nhật thông tin của người khác
            }

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
    }
}







