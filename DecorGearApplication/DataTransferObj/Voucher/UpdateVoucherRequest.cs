using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class UpdateVoucherRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string VoucherName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm giá")]
        [Range(0, 100, ErrorMessage = ("Phần trăm giảm giá không hợp lệ"))]
        public int VoucherPercent { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        // Thời gian hết hạn
        public DateTime expiry { get; set; }
        public EntityStatus Status { get; set; }
    }
}
