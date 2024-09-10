using AutoMapper;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] UserCreateRequest userCreateRequest, CancellationToken cancellationToken)
        {
            if (userCreateRequest == null)
            {
                return BadRequest("The request model is null.");
            }

            var user = _mapper.Map<User>(userCreateRequest);
            var result = await _userServices.Register(user, cancellationToken);

            if (result == DecorGearDomain.Enum.ErrorMessage.Successfull)
                return Ok("Account created successfully.");
            else
                return Conflict("Email or UserName already exists."); // Use Conflict (HTTP 409) for duplication errors
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userServices.GetAllUsers(cancellationToken);
            return Ok(users);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userServices.UpdateUser(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Update failed.");
            }
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userServices.DeleteUser(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Deletion failed.");
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userServices.GetUserById(id, cancellationToken);
                if (result == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred.");
            }
        }
    }
}
