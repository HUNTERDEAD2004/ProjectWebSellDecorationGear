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
    public class Cart : EntityBase
    {
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public int CartID { get; set; }

        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int TotalQuantity { get; set; }
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là giá trị dương")]
        public decimal TotalAmount { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // 1 - 1
        public virtual User User { get; set; }
    }
}
