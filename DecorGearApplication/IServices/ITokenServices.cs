using DecorGearApplication.DataTransferObj.User.Login;
using System.Security.Claims;

namespace DecorGearApplication.IServices
{
    public interface ITokenServices
    {
        string GenerateToken(LoginDTO user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
        bool ValidateToken(string token);
    }
}
