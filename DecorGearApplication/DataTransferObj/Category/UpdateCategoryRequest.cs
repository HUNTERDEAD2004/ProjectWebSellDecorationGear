using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Category
{
    public class UpdateCategoryRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string CategoryName { get; set; }

        [Range(1, 8, ErrorMessage = "Hãy thiết lập trạng thái")]
        public EntityStatus Status { get; set; }
    }
}
