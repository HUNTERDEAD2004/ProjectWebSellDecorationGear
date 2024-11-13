namespace DecorGearApplication.DataTransferObj.Cart;

public class CartProductDetail
{
    public string ProductName { get; set; }  // Tên sản phẩm
    public int Quantity { get; set; }        // Số lượng sản phẩm
    public double UnitPrice { get; set; }    // Đơn giá
    public double TotalPrice { get; set; }   // Tổng giá của sản phẩm (Quantity * UnitPrice)
}