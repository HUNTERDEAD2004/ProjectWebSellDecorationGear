namespace DecorGearApplication.DataTransferObj.Token
{
    public class RefreshTokenRequest
    {
        public string ExpiredToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
