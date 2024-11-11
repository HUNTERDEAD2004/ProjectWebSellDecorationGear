namespace DecorGearApplication.DataTransferObj.User.Login
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            if (!string.IsNullOrWhiteSpace(UserName) || !string.IsNullOrWhiteSpace(Password))
            {
                return true;
            }
            return false;
        }
    }
}
