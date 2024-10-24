using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class Sale : EntityBase
    {

        public int SaleID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string SaleName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm giá")]
        [Range(0, 100, ErrorMessage = ("Phần trăm giảm giá không hợp lệ"))]
        public int SalePercent { get; set; }

        [Range(1, 8, ErrorMessage = "Vui lòng lựa chọn từ 1 - 8 <(Hoạt động:1) (Không hoạt động:2) (Xóa:3) (Đang chờ xử lý:4) (Đang chờ kích hoạt:5) (Đang chờ xác nhận:6) (Đang chờ:7) (Khóa:8)> ")]
        public EntityStatus Status { get; set; }


        // Khóa ngoại

        // 1 - n
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
