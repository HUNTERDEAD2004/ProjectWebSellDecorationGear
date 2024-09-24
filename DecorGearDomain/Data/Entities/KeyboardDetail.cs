using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class KeyboardDetail : EntityBase
    {
        
        public string KeyboardDetailID { get; set; }

        [Required]
        public string ProductID { get; set; }
        

        // thuộc tính
        public string Layout {  get; set; } // bố cục phím 
        public string Case {  get; set; }   // vỏ ngoài 
        public string Switch { get; set; } // trục phím
        public int? SwitchLife { get; set; } // tuổi thọ trục (số lần nhấn)
        public int? BatteryCapacity { get; set; } // dung lượng pin
        public string? Led {  get; set; }
        public string? KeycapMaterial { get; set; } // chất liệu keycap
        public string? SwitchMaterial { get; set; } // chất liệu switch
        public string? SS { get; set; } // (software support) phần mềm hỗ trợ
        public string? Stabilizes { get; set; } // Phụ kiện cân bằng keycap
        public string? PCB { get; set; } // bảng mạch

        //Khóa ngoại 

        // 1 - 1
        public virtual Product Product { get; set; }
    }
}
