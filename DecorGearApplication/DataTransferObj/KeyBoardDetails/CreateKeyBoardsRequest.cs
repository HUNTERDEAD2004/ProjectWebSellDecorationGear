using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class CreateKeyBoardsRequest
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Color { get; set; } // Màu sắc 

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Layout { get; set; } // bố cục phím 

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Case { get; set; }   // vỏ ngoài 

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Switch { get; set; } // trục phím

        [Range(0, 10000000, ErrorMessage = "Tuổi thọ không được vượt quá 10000000 lần nhấn")]
        public int? SwitchLife { get; set; } // tuổi thọ trục (số lần nhấn)

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? Led { get; set; }

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? KeycapMaterial { get; set; } // chất liệu keycap

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? SwitchMaterial { get; set; } // chất liệu switch

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? SS { get; set; } // (software support) phần mềm hỗ trợ

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? Stabilizes { get; set; } // Phụ kiện cân bằng keycap

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? PCB { get; set; } // bảng mạch

        [Range(0, int.MaxValue, ErrorMessage = "Dung lượng pin phải là số dương")]
        public int? BatteryCapacity { get; set; } // dung lượng pin

        [Range(0, double.MaxValue, ErrorMessage = "Giá tiền phải là số dương")]
        public double Price { get; set; } // giá tiền

        [Range(0, int.MaxValue, ErrorMessage = "Lượt xem phải là số dương")]
        public int View { get; set; } // lượt xem

        // Hỗ trợ cho api giao hàng

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Size { get; set; } // kích cỡ hàng hóa 

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; } // số lượng

        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng phải là số dương")]
        public double Weight { get; set; } // cân nặng
    }
}
