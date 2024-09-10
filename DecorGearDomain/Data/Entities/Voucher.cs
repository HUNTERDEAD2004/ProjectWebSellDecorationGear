using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class Voucher : EntityBase
    {
        public int VoucherID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string VoucherName {  get; set; }

        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm giá")]
        [Range(0, 100, ErrorMessage = ("Phần trăm giảm giá không hợp lệ"))]
        public int VoucherPercent { get; set; }

        public EntityStatus Status { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
