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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailID { get; set; }

        [Required(ErrorMessage = "ProductID vui lòng không được để trống")]
        public int ProductID { get; set; }

        [Required]
        public int CartID { get; set; }

        [Required(ErrorMessage = "vui lòng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Đơn giá phải là giá trị dương > 0")]
        public double UnitPrice { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }  // Mỗi CartDetail liên kết với một Product

        public virtual Cart Cart { get; set; } 
    }
}
