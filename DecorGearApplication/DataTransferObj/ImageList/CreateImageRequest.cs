namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class CreateImageRequest
    {
        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
