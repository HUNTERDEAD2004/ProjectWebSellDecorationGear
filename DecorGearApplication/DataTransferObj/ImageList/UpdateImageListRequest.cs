using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class UpdateImageListRequest
    {
        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string? Description { get; set; }
    }
}
