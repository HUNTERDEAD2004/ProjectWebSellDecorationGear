using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class ImageListDto
    {
        public int ImageListID { get; set; }

        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        public string ImagePath { get; set; }

        public EntityStatus Status { get; set; }
    }
}
