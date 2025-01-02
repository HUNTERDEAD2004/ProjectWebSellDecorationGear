using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class Product : EntityBase
    {
        public int ProductID { get; set; }

        public int? SaleID { get; set; } 

        public int BrandID { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string? Description { get; set; }

        public string AvatarProduct { get; set; }

        // Khóa ngoại 

        // 1 - n
        public virtual ICollection<Favorite>? Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<CartDetail>? CartDetails { get; set; } = new List<CartDetail>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();
        public virtual ICollection<MouseDetail> MouseDetails { get; set; } = new List<MouseDetail>();
        public virtual ICollection<KeyboardDetail> KeyboardDetails { get; set; } = new List<KeyboardDetail>();
        public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; } = new List<ProductSubCategory>();

        // n - 1
        public virtual Sale Sale { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
