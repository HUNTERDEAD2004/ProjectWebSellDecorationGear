using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
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

        public string SubCategoryName { get; set; }

        public string BrandName { get; set; }

        public string SaleCode { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string AvatarProduct { get; set; }
    }
}
