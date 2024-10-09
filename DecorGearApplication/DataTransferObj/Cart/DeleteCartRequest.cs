using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Cart
{
    public class DeleteCartRequest
    {
        public int CartID { get; set; }

        public string UserID { get; set; }
    }
}
