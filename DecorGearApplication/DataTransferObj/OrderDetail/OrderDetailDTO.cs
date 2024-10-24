using DecorGearApplication.DataTransferObj.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.OrderDetail
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice()
        {
            return (decimal)(Quantity * UnitPrice);
        }
    }
}
