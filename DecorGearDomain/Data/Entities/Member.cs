using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class Member : EntityBase
    {
        [Required(ErrorMessage = "Không được để trống")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số dương")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        public DateTime ExpiryDate { get; set; }

        // Khóa ngoại

        // 1 - 1
        public virtual User User { get; set; }
    }
}
