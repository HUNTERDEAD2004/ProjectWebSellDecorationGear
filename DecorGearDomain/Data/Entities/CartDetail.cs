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

        [Required(ErrorMessage = "ProductID không được để trống.")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "CartID không được để trống.")]
        public int CartID { get; set; }
        public int? OrderID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }  // Mỗi CartDetail liên kết với một Product

        public virtual Cart Cart { get; set; } // Các CartDetail liên kết với một cart
    }
}
