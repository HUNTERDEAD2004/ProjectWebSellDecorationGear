using DecorGearApplication.DataTransferObj.Token;
using DecorGearApplication.DataTransferObj.User.Email;
using DecorGearApplication.DataTransferObj.User.Login;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearInfrastructure.Extention;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenServices _tokenServices;
        private readonly IUserRespository _userRepository;


        public LoginController(IUserRespository iuserRepository, ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
            _userRepository = iuserRepository;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Yêu cầu đăng nhập không hợp lệ.");
            }

            var user = await _userRepository.GetUserByUsernameAsync(request.UserName, HttpContext.RequestAborted);
            if (user == null)
            {
                return NotFound("Người dùng không tồn tại.");
            }

            // Xác thực mật khẩu người dùng nhập vào
            if (!Hash.VerifyPassword(request.Password, user.Password))
            {
                return Unauthorized("Mật khẩu không đúng.");
            }


            var loginDto = new LoginDTO
            {
                UserId = user.UserID,
                Username = user.UserName,
                RoleName = user.Role?.RoleName
            };

            var token = _tokenServices.GenerateToken(loginDto);
            var refreshToken = _tokenServices.GenerateRefreshToken();



            await _userRepository.SaveRefreshTokenAsync(user.UserID, refreshToken);

            return Ok(new { Token = token, RefreshToken = refreshToken });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest("Yêu cầu làm mới token không hợp lệ.");
            }

            var principal = _tokenServices.GetPrincipalFromExpiredToken(request.RefreshToken);
            if (principal == null)
            {
                return Unauthorized();
            }

            // Lấy userId từ claim và chuyển đổi sang kiểu int
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            // Tìm kiếm người dùng theo userId
            var user = await _userRepository.GetUserByIdAsync(userId, HttpContext.RequestAborted);
            if (user == null || user.RefreshToken != request.RefreshToken)
            {
                return Unauthorized();
            }

            // Xóa token cũ
            await _userRepository.RemoveOldRefreshTokenAsync(userId);

            var loginDto = new LoginDTO
            {
                UserId = user.UserID,
                Username = user.UserName,
                RoleName = user.Role?.RoleName
            };

            // Tạo token mới
            var newToken = _tokenServices.GenerateToken(loginDto);
            var newRefreshToken = _tokenServices.GenerateRefreshToken();

            // Lưu refresh token mới
            await _userRepository.SaveRefreshTokenAsync(userId, newRefreshToken);

            return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
        }


        [HttpPost("verify-code")]
        public async Task<IActionResult> VerifyCode(VerifyCodeRequest request, CancellationToken cancellationToken)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRepository.VerifyCodeAsync(request, cancellationToken);
            if (result.Status == StatusCodes.Status200OK)
            {
                return Ok(result);
            }

            return StatusCode(result.Status, result.Message);
        }
        [HttpPost("resend-verification-code")]
        public async Task<IActionResult> ResendVerificationCode([FromBody] string email)
        {
            var response = await _userRepository.ResendVerificationCodeAsync(email, CancellationToken.None);
            return StatusCode(response.Status, response.Message);
        }
     
    }

}



