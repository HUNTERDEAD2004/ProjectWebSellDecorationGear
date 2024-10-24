namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class CreateFeedBackRequest
    {
        public int UserID { get; set; }

        public int ProductID { get; set; }

        public string Comment { get; set; }
    }
}
