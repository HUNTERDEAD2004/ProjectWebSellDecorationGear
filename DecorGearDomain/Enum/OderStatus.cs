namespace DecorGearDomain.Enum
{
    public enum OrderStatus
    {

        Pending = 1,         // Đơn hàng đang chờ xử lý
        Confirmed = 2,       // Đơn hàng đã được xác nhận
        Processing = 3,      // Đơn hàng đang được xử lý
        Shipped = 4,         // Đơn hàng đã được giao cho đơn vị vận chuyển
        OutForDelivery = 5,  // Đơn hàng đang trên đường giao
        Delivered = 6,       // Đơn hàng đã được giao
        Cancelled = 7,       // Đơn hàng đã bị hủy
        Returned = 8,        // Đơn hàng đã được trả lại
        Refunded = 9         // Đơn hàng đã được hoàn tiền
    }
}
