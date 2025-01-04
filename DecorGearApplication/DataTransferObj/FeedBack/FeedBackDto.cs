using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class FeedBackDto
    {
        public int FeedBackID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public string Comment { get; set; }

        public EntityStatus Status { get; set; }
    }
}
