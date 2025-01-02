using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Member
{
    public class CreateMemberRequest
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số dương")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        public DateTime ExpiryDate { get; set; }
    }
}
