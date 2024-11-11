namespace DecorGearDomain.Enum
{
    public enum EntityStatus
    {
        Active = 1, // Hoạt động
        Inactive = 2, // Không hoạt động
        Deleted = 3, // Xóa
        Pending = 4, // Đang chờ xử lý
        PendingForActivation = 5, // Đang chờ kích hoạt
        PendingForConfirmation = 6, // Đang chờ xác nhận
        PendingForApproval = 7, // Đang chờ 
        Locked = 8, // Khóa
    }
}
