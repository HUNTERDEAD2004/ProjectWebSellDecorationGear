using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Sale
{
    public class CreateSaleRequest
    {
        public string SaleName { get; set; }

        public int SalePercent { get; set; }

        public int UserID { get; set; }
    }
}
