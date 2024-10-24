namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class CreateImageRequest
    {
        public int ProductID { get; set; }

        public List<string> ImagePath { get; set; }

        public string Description { get; set; }
    }
}
