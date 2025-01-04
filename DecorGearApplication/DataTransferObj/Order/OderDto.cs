using DecorGearApplication.DataTransferObj.OrderDetail;
using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.Order
{
    public class OderDto
    {
        public int OderID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public int? VoucherID { get; set; }

        public int totalQuantity { get; set; }

        public decimal totalPrice { get; set; }

        public string paymentMethod { get; set; }

        public string size { get; set; }

        public float weight { get; set; }

        public DateTime OrderDate { get; set; }

        public EntityStatus Status { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetailDTO> orderDetailDTOs { get; set; } = new List<OrderDetailDTO>();
    }
}
