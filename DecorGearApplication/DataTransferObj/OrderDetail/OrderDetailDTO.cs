using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

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
        public double UnitPrice { get; set; }
        public decimal TotalPrice()
        {
            return (decimal)(Quantity * UnitPrice);
        }

        public EntityStatus Status { get; set; }
    }
}
