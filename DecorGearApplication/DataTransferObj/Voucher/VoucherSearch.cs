using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class VoucherSearch
    {
        public string? VoucherName { get; set; }
        public double? VoucherPercent { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
