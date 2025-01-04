using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class UpdateImageListRequest
    {
        public int? MouseDetailID { get; set; }

        public int? KeyboardDetailID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string ImagePath { get; set; }

        [Range(1, 8, ErrorMessage = "Hãy thiết lập trạng thái")]
        public EntityStatus Status { get; set; }
    }
}
