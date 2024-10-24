using DecorGearApplication.DataTransferObj.OrderDetail;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecorGearDomain.Data.Entities;

namespace DecorGearApplication.DataTransferObj.Order
{
    public class OderDto
    {
        public int OderID { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }

        public int? VoucherID { get; set; }

        public int totalQuantity { get; set; }

        public decimal totalPrice { get; set; }

        public string paymentMethod { get; set; }

        public string size { get; set; }

        public float weight { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderDetailDTO> orderDetailDTOs { get; set; } = new List<OrderDetailDTO>(); 
    }
}
