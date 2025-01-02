using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Brand
{
    public class UpdateBrandRequest
    {
        public int BrandID { get; set; }

        [Required(ErrorMessage = " Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string BrandName { get; set; }

        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public string Description { get; set; }
    }
}
