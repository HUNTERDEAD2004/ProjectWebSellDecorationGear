using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Order
{
    public class UpdateOrderRequest
    {
        public int OderID { get; set; }

        public string UserID { get; set; }

        public int totalQuantity { get; set; }

        public decimal totalPrice { get; set; }

        public string paymentMethod { get; set; }

        public float size { get; set; }

        public float weight { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
