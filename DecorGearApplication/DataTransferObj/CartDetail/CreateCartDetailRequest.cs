namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class CreateCartDetailRequest
    {
        public int UserID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
