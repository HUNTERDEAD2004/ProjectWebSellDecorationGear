namespace Ecommerce.Application.DataTransferObj.User.Ultilities
{
    public class ForgotPasswordRequest
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPW { get; set; }
    }
}
