using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using Ecommerce.Application.DataTransferObj.User;
using Ecommerce.Application.DataTransferObj.User.Ultilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Cấu hình JWT và các thông tin khác
        private readonly AppDbContext _db; // Context của cơ sở dữ liệu

        public LoginController(IConfiguration configuration, AppDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await GetUserFromDatabase(request.UserName, request.Password); // Lấy thông tin người dùng từ cơ sở dữ liệu
                if (user == null)
                    return Unauthorized(); // Trả về lỗi 401 nếu không tìm thấy người dùng

                var token = GenerateToken(user); // Tạo JWT token
                return Ok(new { Token = token }); // Trả về token trong phản hồi
            }
            catch (Exception ex)
            {
                // Log lỗi (sử dụng framework log)
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi khi xử lý yêu cầu của bạn."); // Trả về lỗi 500 nếu có lỗi xảy ra
            }
        }

        private string GenerateToken(LoginDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])); // Khóa bí mật dùng để ký token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Thiết lập các thông tin ký token

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId), // Claim cho ID người dùng
                new Claim(ClaimTypes.Name, user.Username), // Claim cho tên người dùng
                new Claim(ClaimTypes.Role, user.RoleName) // Claim cho tên role
            };

            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"], // Issuer của token
                _configuration["JWT:Audience"], // Audience của token
                claims,
                expires: DateTime.UtcNow.AddMinutes(120), // Thời gian hết hạn của token
                signingCredentials: creds); // Các thông tin ký token

            return new JwtSecurityTokenHandler().WriteToken(token); // Trả về token dưới dạng chuỗi
        }

        private async Task<LoginDTO> GetUserFromDatabase(string username, string password)
        {
            var encryptedPassword = HashKey.EncryptPassword(password, password); // Mã hóa mật khẩu người dùng (kiểm tra phương thức mã hóa chính xác)
            var user = await _db.Users
                .Where(x => x.UserName == username && x.Password == encryptedPassword)
                .Select(u => new { u.UserID, u.UserName })
                .FirstOrDefaultAsync(); // Lấy thông tin người dùng từ cơ sở dữ liệu

            if (user == null) return null; // Trả về null nếu không tìm thấy người dùng

            var roleUser = await _db.Roles
                .Where(x => x.CreatedBy == user.UserID)
                .Select(ru => ru.RoleID)
                .FirstOrDefaultAsync(); // Lấy ID role của người dùng

            var roleName = await _db.Roles
                .Where(x => x.RoleID == roleUser)
                .Select(r => r.RoleName)
                .FirstOrDefaultAsync(); // Lấy tên role của người dùng

            return new LoginDTO()
            {
                UserId = user.UserID.ToString(), 
                Username = user.UserName,
                RoleName = roleName
            };
        }
    }
}
