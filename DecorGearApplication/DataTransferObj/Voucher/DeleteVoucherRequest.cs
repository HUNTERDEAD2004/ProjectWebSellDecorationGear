﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class DeleteVoucherRequest
    {
        public int VoucherID { get; set; }

        public int UserID { get; set; }
    }
}