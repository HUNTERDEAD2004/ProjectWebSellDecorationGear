using AutoMapper;
using DecorGearApplication.DataTransferObj.User.Request;
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
        public async Task<IActionResult> UpdateUser(int id, UserUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.UpdateUser(id, request, cancellationToken);

            if (result.Status == StatusCodes.Status200OK)
            {
                var updatedFields = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(request.Name))
                {
                    updatedFields.Add("name", request.Name);
                }
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                {
                    updatedFields.Add("phoneNumber", request.PhoneNumber);
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    updatedFields.Add("email", request.Email);
                }
                if (!string.IsNullOrEmpty(request.UserName))
                {
                    updatedFields.Add("userName", request.UserName);
                }

                return Ok(new
                {
                    status = 200,
                    message = "Cập nhật người dùng thành công.",
                    data = updatedFields
                });
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







