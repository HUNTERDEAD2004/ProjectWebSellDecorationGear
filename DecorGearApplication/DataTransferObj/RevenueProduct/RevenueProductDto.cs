using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.RevenueProduct
{
    public class RevenueProductDto
    {
        public string Name { get; set; }
        public int? TotalProducr { get; set; }// số sản phẩm bán ra
        public double? TotalRevenue { get; set; }
        //
        public int CountQuatityByMonth { get; set; }
        public double RevenueNow { get; set; }
        public double TotalQuatityByMonth { get; set; }
    }
}
