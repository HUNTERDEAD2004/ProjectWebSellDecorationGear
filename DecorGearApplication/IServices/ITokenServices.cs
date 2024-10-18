using DecorGearApplication.DataTransferObj.User.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
