using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class OrderDetail : EntityBase
    {
        public Guid OrderDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public Guid ProductID { get; set; }

        [Required(ErrorMessage = "vui lòng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Đơn giá phải là giá trị dương")]
        public decimal UnitPrice { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
