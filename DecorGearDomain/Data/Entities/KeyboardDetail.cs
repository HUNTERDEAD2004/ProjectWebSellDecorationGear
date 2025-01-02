using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class KeyboardDetail : EntityBase
    {
        public int KeyboardDetailID { get; set; } 

        public int ProductID { get; set; }

        // thuộc tính

        public string Color { get; set; } // Màu sắc

        public string Layout { get; set; } // bố cục phím 

        public string Case { get; set; }   // vỏ ngoài 

        public string SwitchMaterial { get; set; } // chất liệu switch

        public string Switch { get; set; } // trục phím

        public int SwitchLife { get; set; } // tuổi thọ trục (số lần nhấn)

        public string? Led { get; set; }

        public string? KeycapMaterial { get; set; } // chất liệu keycap

        public string? SS { get; set; } // (software support) phần mềm hỗ trợ

        public string? Stabilizes { get; set; } // Phụ kiện cân bằng keycap

        public string? PCB { get; set; } // bảng mạch

        public int? BatteryCapacity { get; set; } // dung lượng pin

        public double Price { get; set; } // giá tiền

        public int View { get; set; } // lượt xem

        // Hỗ trợ cho api giao hàng

        public string Size { get; set; } // kích cỡ hàng hóa

        public int Quantity { get; set; } // số lượng

        public double Weight { get; set; } // cân nặng

        //Khóa ngoại 

        // 1 - 1
        public virtual Product Product { get; set; }

        // 1 - n
        public virtual ICollection<ImageList>? ImageLists { get; set; } = new List<ImageList>();
    }
}
