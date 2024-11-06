

namespace DecorGearApplication.DataTransferObj.Home
{
    public class TopHotProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public int TotalSold { get; set; } // Tổng số lượng bán ra
        public int FavoriteCount { get; set; } // Số lượng yêu thích nếu bạn muốn tính sản phẩm yêu thích

        public string BrandName { get; set; }
        public string SubCategoryName { get; set; }
    }
}
