using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class KeyboardDetail : EntityBase
    {
        public int KeyboardDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        // thuộc tính
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

        //Khóa ngoại 

        // 1 - 1
        public virtual Product Product { get; set; }
    }
}
