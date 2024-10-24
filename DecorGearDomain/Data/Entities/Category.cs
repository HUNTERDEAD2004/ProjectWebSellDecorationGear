using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class Category : EntityBase
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string CategoryName { get; set; }

        //Khóa ngoại

        // 1 - n
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
