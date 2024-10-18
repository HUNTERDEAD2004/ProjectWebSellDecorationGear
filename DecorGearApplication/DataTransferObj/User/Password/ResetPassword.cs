using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.User.Password
{
    public class ResetPassword
    {
      //  public string Email { get; set; }
        public string VerificationCodePw { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPW { get; set; }
    }
}
