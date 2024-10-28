using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.User.Password
{
    public class ResetPassword
    {
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Mã xác thực phải gồm 6 chữ số.")]
        public string VerificationCodePw { get; set; }

        [Required(ErrorMessage = "Mật khẩu mới không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Xác nhận mật khẩu không trùng với mật khẩu mới")]
        public string ConfirmPW { get; set; }
    }
}
