namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class ImageListDto
    {
        public int ImageListID { get; set; }

        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
