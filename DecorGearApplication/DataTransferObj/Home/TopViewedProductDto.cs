

namespace DecorGearApplication.DataTransferObj.Home
{
    public class TopViewedProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int View { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public int? BatteryCapacity { get; set; }

        public string BrandName { get; set; }
        public string SubCategoryName { get; set; }
    }
}
