namespace DecorGearApplication.DataTransferObj.User.Password
{
    public class ChangePasswordRequest
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConFirm { get; set; }
    }
}
