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
        public int? TotalProducr { get; set; }  // Số sản phẩm bán ra
        public double? TotalRevenue { get; set; }  // Tổng doanh thu
        public int TotalQuantity { get; set; }  // Tổng số lượng bán


        //

    }
}
