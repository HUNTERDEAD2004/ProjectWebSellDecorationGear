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
        public string MouseDetailID { get; set; }

        [Required]
        public string ProductID { get; set; }

        // thuộc tính
        public string Color { get; set; } // Màu sắc

        public int? DPI { get; set; } // tốc độ di chuyển mặt đọc trên pixel

        public string Connectivity { get; set; } // Kết nối (ví dụ: USB, Bluetooth)

        public string Dimensions { get; set; } // Kích thước

        public string Material { get; set; } // vật liệu

        public string? EyeReading { get; set; }   //(tần số quét )

        public int? Button {  get; set; } // số nút bấm

        public string? BatteryCapacity { get; set; } // dung lượng pin nếu có

        public string? LED {  get; set; }

        public string? SS { get; set; } // (software support) phần mềm hỗ trợ

        //Khóa ngoại 

        // 1 - 1
        public virtual Product Product { get; set; }
    }
}
