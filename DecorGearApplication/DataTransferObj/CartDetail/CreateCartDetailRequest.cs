using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class CreateCartDetailRequest
    {
        public Guid UserID { get; set; }

        public Guid ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
