using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Enum
{
    public enum OrderStatus
    {
        Chuathanhtoan,
        OrderConfirmed, // Hoàn thành
        Paid, // Hoãn
        Canceled, // Hủy
        InTransit, // Đang vận chuyển
        Delivered, // Đã giao hàng
    }
}
