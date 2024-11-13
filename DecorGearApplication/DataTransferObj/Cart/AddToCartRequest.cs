namespace DecorGearApplication.DataTransferObj.Cart
{
    public class AddToCartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
