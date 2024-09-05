using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj
{
    public class CartDto
    {
        public int CartID { get; set; }

        public string UserID { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
