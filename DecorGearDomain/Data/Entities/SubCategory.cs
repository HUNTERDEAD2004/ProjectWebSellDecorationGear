using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class SubCategory : EntityBase
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }
        // Khóa ngoại

        // n - 1
        public virtual Category Category { get; set; }

        // 1 - n
        public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; } = new List<ProductSubCategory>();
    }
}
