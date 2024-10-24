namespace DecorGearApplication.DataTransferObj.Member
{
    public class UpdateMemberRequest
    {
        public int? UserID { get; set; }

        public int Points { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
