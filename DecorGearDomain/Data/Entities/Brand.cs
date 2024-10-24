using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class Brand : EntityBase
    {
        public int BrandID { get; set; }

        [Required(ErrorMessage = " Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string BrandName { get; set; }

        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public string Description { get; set; }

        // Khóa ngoại

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
