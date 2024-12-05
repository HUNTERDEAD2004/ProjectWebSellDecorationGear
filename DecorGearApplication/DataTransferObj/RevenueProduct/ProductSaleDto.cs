using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.RevenueProduct
{
    public class ProductSaleDto
    {
        public double? TotalAmount { get; set; } // Tổng tiền
        public int? TotalQuantity { get; set; }   // Tổng số lượng
        public int? ProductCode { get; set; }  // Mã sản phẩm
        public string? Name { get; set; }  // Mã sản phẩm
        public DateTime StartDate { get; set; }  // Thời gian bắt đầu
        public DateTime EndDate { get; set; }    // Thời gian kết thúc
    }
}
