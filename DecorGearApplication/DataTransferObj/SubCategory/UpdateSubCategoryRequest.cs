using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class UpdateSubCategoryRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }
    }
}
