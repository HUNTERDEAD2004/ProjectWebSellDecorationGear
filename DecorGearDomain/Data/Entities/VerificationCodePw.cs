namespace DecorGearDomain.Data.Entities
{
    public class VerificationCodePw
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } // Thời gian tạo mã
        public DateTime Expiration { get; set; } // Thời gian hết hạn
    }
}
