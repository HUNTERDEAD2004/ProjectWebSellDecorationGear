using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class MouseDetail : EntityBase
    {
        [Required(ErrorMessage = "Không được để trống")]
        public Guid MouseDetailID { get; set; }


        [Required(ErrorMessage = "Không được để trống")]
        public Guid ProductID { get; set; }

        // thuộc tính
        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]      
        public string Color { get; set; } // Màu sắc

        // thuộc tính
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

        [Range(0,20, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public int? Button { get; set; } // số nút bấm

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? LED { get; set; }

        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? SS { get; set; } // (software support) phần mềm hỗ trợ

        //Khóa ngoại 

        // 1 - 1
        public virtual Product Product { get; set; }
    }
}
