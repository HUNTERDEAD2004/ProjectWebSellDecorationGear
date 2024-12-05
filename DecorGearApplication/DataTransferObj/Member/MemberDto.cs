namespace DecorGearApplication.DataTransferObj.Member
{
    public class MemberDto
    {
        public int MemberID { get; set; }

        public int? UserID { get; set; }

        public int Points { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
