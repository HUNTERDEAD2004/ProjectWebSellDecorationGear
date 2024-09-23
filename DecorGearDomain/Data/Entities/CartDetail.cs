using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecorGearDomain.Data.Base;

namespace DecorGearDomain.Data.Entities
{
    public class CartDetail : EntityBase
    {
        public int CartDetailID { get; set; }

        [Required]
        public string ProductID { get; set; }

        [Required]
        public int CartID { get; set; }

        public int OrderID { get; set; }
        
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }  // Mỗi CartDetail liên kết với một Product

        public virtual Cart Cart { get; set; } // Các CartDetail liên kết với một cart
    }
}
