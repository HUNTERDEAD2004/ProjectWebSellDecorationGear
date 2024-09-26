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
        public string ProductID { get; set; } // ID = 2 chự cái đầu của hãng + kèm tên đặc biệt của sản phẩm + số thứ tự

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int View { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public int? SaleID { get; set; }  // có thể có hoặc không

        public string BrandID { get; set; }

        public int SubCategoryID { get; set; }

        public int OrderID { get; set; }
    }
}
