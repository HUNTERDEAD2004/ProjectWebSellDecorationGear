using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.MouseDetails
{
    public class UpdateMouseRequest
    {
        public string MouseDetailID { get; set; }

        public string UserID { get; set; }

        public string Color { get; set; }

        public string? DPI { get; set; }

        public string Connectivity { get; set; }

        public string Dimensions { get; set; }

        public string Weight { get; set; }

        public string Material { get; set; }

        public string? EyeReading { get; set; }

        public string? Button { get; set; }

        public string? BatteryCapacity { get; set; }

        public string? LED { get; set; }

        public string? SS { get; set; }
    }
}
