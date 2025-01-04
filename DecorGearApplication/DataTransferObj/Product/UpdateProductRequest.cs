using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Product
{
    public class UpdateProductRequest
    {
        public int ProductID { get; set; }

        public int? SaleID { get; set; }

        public int BrandID { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(200, ErrorMessage = "Chuỗi không được vượt quá 100 ký tự")]
        public string AvatarProduct { get; set; }

        [Range(1, 8, ErrorMessage = "Hãy thiết lập trạng thái")]
        public EntityStatus Status { get; set; }
    }
}
