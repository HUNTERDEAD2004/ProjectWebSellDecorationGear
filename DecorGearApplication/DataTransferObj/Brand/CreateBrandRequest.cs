using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Brand
{
    public class CreateBrandRequest
    {
        [Required(ErrorMessage = " Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string BrandName { get; set; }

        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public string Description { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
