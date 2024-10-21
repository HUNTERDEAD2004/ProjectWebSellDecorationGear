using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.User.Email
{
   public class VerifyCodeRequest
    {
        public string Email { get; set; } 
        public string Code { get; set; } 
    }
}
