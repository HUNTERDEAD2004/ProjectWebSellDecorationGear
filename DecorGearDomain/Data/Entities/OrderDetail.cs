using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }    

    }
}
