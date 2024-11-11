namespace Ecommerce.Application.DataTransferObj.User.Ultilities
{
    public class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConFirm { get; set; }
    }
}
