using DecorGearApplication.DataTransferObj.Cart;

namespace DecorGearApplication.DataTransferObj.CartDetail;

public class CartDetailsResponse
{
    public double TotalAmount { get; set; }
    public double TotalItems { get; set; }
    public List<CartProductDetail> Products { get; set; } = new List<CartProductDetail>();
}