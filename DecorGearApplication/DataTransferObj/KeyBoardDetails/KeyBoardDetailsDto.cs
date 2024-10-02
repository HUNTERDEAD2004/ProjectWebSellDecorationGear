using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class KeyBoardDetailsDto
    {
        public Guid KeyboardDetailID { get; set; }

        public Guid ProductID { get; set; }

        public string Layout { get; set; } 

        public string Case { get; set; }   

        public string Switch { get; set; } 

        public int? SwitchLife { get; set; }  

        public string? Led { get; set; }

        public string? KeycapMaterial { get; set; } 

        public string? SwitchMaterial { get; set; } 

        public string? SS { get; set; } 

        public string? Stabilizes { get; set; } 

        public string? PCB { get; set; } 
    }
}
