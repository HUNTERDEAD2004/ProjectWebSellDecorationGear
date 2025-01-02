using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class CreateImageRequest
    {
        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(500, ErrorMessage = "chuỗi Không được vượt quá 500 ký tự")]
        public string ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string? Description { get; set; }
    }
}
