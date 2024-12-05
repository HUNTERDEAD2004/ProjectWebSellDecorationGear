namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class UpdateImageListRequest
    {
        public int ProductID { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
