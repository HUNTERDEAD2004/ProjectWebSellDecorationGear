namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class CreateCartDetailRequest
    {
        public int ProductID { get; set; }

        public int CartID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}
