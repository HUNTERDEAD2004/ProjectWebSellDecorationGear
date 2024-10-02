using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Sale
{
    public class SaleDto
    {
        public Guid SaleID { get; set; }

        public string SaleName { get; set; }

        public int SalePercent { get; set; }
    }
}
