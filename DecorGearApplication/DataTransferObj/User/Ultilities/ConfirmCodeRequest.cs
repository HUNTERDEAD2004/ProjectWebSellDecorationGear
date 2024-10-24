namespace Ecommerce.Application.DataTransferObj.User.Ultilities
{
    public class ConfirmCodeRequest
    {
        public Guid ID { get; set; }
        public string? Code { get; set; }
    }
}
