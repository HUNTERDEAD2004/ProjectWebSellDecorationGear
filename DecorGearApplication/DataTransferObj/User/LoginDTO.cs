using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DataTransferObj.User
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string RoleName { get; set; } 
        public string? UserId { get; set; } 

    }
}
