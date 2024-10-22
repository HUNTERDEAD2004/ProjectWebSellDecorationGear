using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class OrderDetail : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "vui lòng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Đơn giá phải là giá trị dương")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(10, ErrorMessage = "Size được phụ thuộc vào chuẩn")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Cân nặng được phụ thuộc vào chuẩn")]
        public double Weight { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
