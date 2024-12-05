using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Password;
using DecorGearApplication.IServices;
using DecorGearDomain.Enum;
using Microsoft.AspNetCore.Mvc;


namespace DecorGearApi.Controllers.User
{
    [ApiController]
    [Route("api/user/[controller]")]

    public class PasswordController : ControllerBase
    {
        private readonly IPasswordServices _passwordService;
        public PasswordController(IPasswordServices passwordServices)
        {
            _passwordService = passwordServices;

        }
        [HttpPost("change-password")]
        public async Task<ActionResult<ResponseDto<ErrorMessage>>> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _passwordService.ChangePassword(request, cancellationToken);
            if (result.Message == "Đặt lại mật khẩu thành công.")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<ResponseDto<ErrorMessage>>> ForgotPassword([FromBody] ForgotPassword request, CancellationToken cancellationToken)
        {
            var result = await _passwordService.ForgotPassword(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ResponseDto<ErrorMessage>>> ResetPassword([FromBody] ResetPassword request, CancellationToken cancellationToken)
        {
            var result = await _passwordService.ResetPassword(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

