using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj
{
    public class CartDto
    {
        public int CartID { get; set; }

        public int UserID { get; set; }

        public List<CartDetailDto> cartDetails { get; set; } = new List<CartDetailDto> { };

        public int TotalQuantity => cartDetails.Sum(x => x.Quantity);

        public decimal TotalPrice => cartDetails.Sum(x => x.UnitPrice * x.TotalPrice);

        public EntityStatus Status { get; set; } 
    }
}
