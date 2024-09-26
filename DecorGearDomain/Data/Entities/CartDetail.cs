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
        public Guid CartDetailID { get; set; }

        [Required(ErrorMessage = "ProductID vui lòng không được để trống")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "CartID vui lòng không được để trống")]
        public string CartID { get; set; }

        [Required(ErrorMessage = "vui lòng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Đơn giá phải là giá trị dương > 0")]
        public double UnitPrice { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Phải là giá trị dương > 0")]
        public double TotalPrice { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }  

        public virtual Cart Cart { get; set; } 
    }
}
