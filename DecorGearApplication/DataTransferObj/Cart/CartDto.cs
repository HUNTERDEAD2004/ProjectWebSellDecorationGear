using DecorGearApplication.DataTransferObj.CartDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj
{
    public class CartDto
    {
        public int CartID { get; set; }

        public int UserID { get; set; }

        public List<CartDetailDto> cartDetails { get; set; } = new List<CartDetailDto> { };
        public int TotalQuantity => cartDetails.Sum(x => x.Quantity);

        public decimal TotalPrice => cartDetails.Sum(x => x.UnitPrice * x.TotalPrice);
    }
}
