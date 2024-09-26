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
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public string VoucherID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string VoucherName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm giá")]
        [Range(0, 100, ErrorMessage = ("Phần trăm giảm giá không hợp lệ"))]
        public int VoucherPercent { get; set; }

        [Range(1,8, ErrorMessage = "Vui lòng lựa chọn từ 1 - 8 <(Hoạt động:1) (Không hoạt động:2) (Xóa:3) (Đang chờ xử lý:4) (Đang chờ kích hoạt:5) (Đang chờ xác nhận:6) (Đang chờ:7) (Khóa:8)> ")]
        public EntityStatus Status { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
