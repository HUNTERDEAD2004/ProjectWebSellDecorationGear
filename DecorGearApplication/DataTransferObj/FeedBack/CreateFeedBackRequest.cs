using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class CreateFeedBackRequest
    {
        [Required(ErrorMessage = "Không được để trống")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        [StringLength(500, ErrorMessage = "Bình luận không được vượt quá 500 ký tự")]
        public string Comment { get; set; }
    }
}
