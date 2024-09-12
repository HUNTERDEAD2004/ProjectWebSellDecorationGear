using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class UpdateVoucherRequest
    {
        public int VoucherID { get; set; }

        public string VoucherName { get; set; }

        public int VoucherPercent { get; set; }

        public string UserID { get; set; }
    }
}
