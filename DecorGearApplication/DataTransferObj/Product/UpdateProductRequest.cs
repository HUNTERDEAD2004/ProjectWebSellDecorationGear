﻿namespace DecorGearApplication.DataTransferObj.Product
{
    public class UpdateProductRequest
    {
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int View { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public int? BatteryCapacity { get; set; } // dung lượng pin

        public string AvatarProduct { get; set; }

        public int? SaleID { get; set; }  // có thể có hoặc không

        public int BrandID { get; set; }

        public int SubCategoryID { get; set; }
    }
}
