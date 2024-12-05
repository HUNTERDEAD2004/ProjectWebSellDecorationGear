namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class ImageListDto
    {
        public int ImageListID { get; set; }

        public int ProductID { get; set; }

        public List<string> ImagePath { get; set; }

        public string Description { get; set; }
    }
}
