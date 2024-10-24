namespace DecorGearApplication.DataTransferObj.Member
{
    public class CreateMemberRequest
    {
      

        public int? UserID { get; set; }

        public int Points { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
