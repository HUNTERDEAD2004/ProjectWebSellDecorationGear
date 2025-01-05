using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Product
{
    public class ProductDto
    {
        public int ProductID { get; set; }

        public int? SaleID { get; set; }

        public int BrandID { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string? Description { get; set; }

        public string AvatarProduct { get; set; }

        public EntityStatus Status { get; set; }

        public List<string> SubCategories { get; set; }

        public List<string>? ImageProduct { get; set; }

        public object? ProductDetail { get; set; }

        public string? CategoryName { get; set; }

        public int? CategoryID { get; set; }

        public string? BrandName { get; set; }

        public int? SalePercent { get; set; }

        public double? Price { get; set; }

        public int? View { get; set; }

        public int? Quantity { get; set; }
    }
}
