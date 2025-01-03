using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class Brand : EntityBase
    {
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public EntityStatus Status { get; set; }

        // Khóa ngoại

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
