namespace DecorGearDomain.Enum
{
    public enum PaymentStatus
    {
        Pending = 1,           // Thanh toán đang chờ xử lý
        Completed = 2,         // Thanh toán đã hoàn tất
        Failed = 3,            // Thanh toán không thành công
        Refunded = 4,          // Thanh toán đã được hoàn tiền
        PartiallyRefunded = 5, // Một phần thanh toán đã được hoàn tiền
        Cancelled = 6          //Thanh toán đã bị hủy

    }
}
