using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class VoucherDto
    {
        public Guid VoucherID { get; set; }

        public string VoucherName { get; set; }

        public int VoucherPercent { get; set; }
    }
}
