using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class UpdateVoucherRequest
    {

        public string VoucherName { get; set; }
        public int VoucherPercent { get; set; }

        public int UserID { get; set; }
        public string expiry { get; set; }
    }
}
