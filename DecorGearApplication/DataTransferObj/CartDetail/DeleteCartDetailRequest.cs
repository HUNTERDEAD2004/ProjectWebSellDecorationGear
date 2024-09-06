using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.CartDetail
{
    public class DeleteCartDetailRequest
    {
        public int CartDetailID { get; set; }

        public string UserID { get; set; }
    }
}
