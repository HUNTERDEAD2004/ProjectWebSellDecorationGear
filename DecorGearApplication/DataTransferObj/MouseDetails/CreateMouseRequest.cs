using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.MouseDetails
{
    public class CreateMouseRequest
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Color { get; set; } // Màu sắc

        [Required(ErrorMessage = "Không được để trống.")]
        [Range(0, 20000, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public int DPI { get; set; } // Độ phân giải

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Connectivity { get; set; } // Kết nối (ví dụ: USB, Bluetooth)

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Dimensions { get; set; } // Kích thước

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Material { get; set; } // vật liệu

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? EyeReading { get; set; }   //(tần số quét )

        [Range(0, 20, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public int? Button { get; set; } // số nút bấm

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? LED { get; set; }

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? SS { get; set; } // (software support) phần mềm hỗ trợ

        [Range(0, int.MaxValue, ErrorMessage = "Dung lượng pin phải là số dương")]
        public int? BatteryCapacity { get; set; } // dung lượng pin

        [Range(0, double.MaxValue, ErrorMessage = "Giá tiền phải là số dương")]
        public double Price { get; set; } // giá tiền

        [Range(0, int.MaxValue, ErrorMessage = "Lượt xem phải là số dương")]
        public int View { get; set; } // lượt xem

        public EntityStatus Status { get; set; } = EntityStatus.Active;

        // Hỗ trợ cho api giao hàng

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Size { get; set; } // kích cỡ hàng hóa 

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; } // số lượng

        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng phải là số dương")]
        public double Weight { get; set; } // cân nặng
    }
}
