using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Product
{
    public class ViewProductRequest
    {
        public int? ProductID { get; set; }

        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public int? View { get; set; }

        public int? Quantity { get; set; }

        public double? Weight { get; set; }

        public string? Description { get; set; }

        public string? Size { get; set; }

        public int? BatteryCapacity { get; set; }
    }
}
