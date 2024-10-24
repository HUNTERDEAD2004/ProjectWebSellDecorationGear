namespace DecorGearApplication.DataTransferObj.Order
{
    public class OrderDto
    {
        public int OderID { get; set; }

        public int UserID { get; set; }

        public int? VoucherID { get; set; }

        public int totalQuantity { get; set; }

        public decimal totalPrice { get; set; }

        public string paymentMethod { get; set; }

        public float size { get; set; }

        public float weight { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
