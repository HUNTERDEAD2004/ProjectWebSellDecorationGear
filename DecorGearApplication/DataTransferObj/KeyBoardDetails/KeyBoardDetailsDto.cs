namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class KeyBoardDetailsDto
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

        public string? Led { get; set; } // Đèn led

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

        // Sửa thuộc tính ImageProduct thành List<string>

        public List<string> ImageProduct { get; set; } // list ảnh
    }
}
