using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.User.Email
{
    public class WelcomeRequestDto
    {
        public string Email { get; set; } // Địa chỉ email của người dùng
        public string UserName { get; set; } // Tên người dùng
    }
}
