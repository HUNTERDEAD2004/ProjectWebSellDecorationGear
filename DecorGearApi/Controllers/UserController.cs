using AutoMapper;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.implement;
using Ecommerce.Application.DataTransferObj.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public UserController(IUserServices userServices, IMapper mapper, ITokenServices tokenServices)
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

            var result = await _userServices.Register( request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }

            return StatusCode(result.Status, result.Message);
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

            var result = await _userServices.UpdateUser( id, request, cancellationToken);

           
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result); 
            }

            return StatusCode(result.Status, result.Message); 
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var result = await _userServices.DeleteUser(id, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return NotFound("User not found."); 
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

            // Người dùng thường chỉ có thể xem thông tin của chính mình
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

       
    }
}






