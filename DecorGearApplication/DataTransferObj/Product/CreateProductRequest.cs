using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Product
{
    public class CreateProductRequest
    {
        public string UserID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string View { get; set; }

        public string Quantity { get; set; }

        public string Weight { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public int? SaleID { get; set; }

        public string BrandID { get; set; }

        public int SubCategoryID { get; set; }
    }
}
