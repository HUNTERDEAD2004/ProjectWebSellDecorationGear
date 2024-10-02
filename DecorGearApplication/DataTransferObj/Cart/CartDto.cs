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
        public Guid CartID { get; set; }

        public Guid UserID { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
