using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class UpdateKeyBoardsRequest
    {
        public string KeyboardDetailID { get; set; }

        public string UserID { get; set; }

        public string Layout { get; set; }

        public string Case { get; set; }

        public string Switch { get; set; }

        public string? SwitchLife { get; set; }

        public string? BatteryCapacity { get; set; }

        public string? Led { get; set; }

        public string? KeycapMaterial { get; set; }

        public string? SwitchMaterial { get; set; }

        public string? SS { get; set; }

        public string? Stabilizes { get; set; }

        public string? PCB { get; set; }
    }
}
