using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class UpdateCartDetailRequest
    {
        public int CartDetailID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        [Range(1, 8, ErrorMessage = "Hãy thiết lập trạng thái")]
        public EntityStatus Status { get; set; }
    }
}
