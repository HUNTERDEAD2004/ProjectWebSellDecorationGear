namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class UpdateCartDetailRequest
    {
        public string UserID { get; set; }

        public string CartDetailID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
