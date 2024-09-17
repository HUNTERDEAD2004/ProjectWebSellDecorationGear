using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string ProductID { get; set; } // ID = 2 chự cái đầu của hãng + kèm tên đặc biệt của sản phẩm + số thứ tự

        [Required(ErrorMessage ="Vui lòng nhập tên")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập giá tiền ")]
        public double Price { get; set; }

        public int View {  get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public int? SaleID { get; set; }  // có thể có hoặc không
        
        [Required]
        public string BrandID { get; set; }

        public int SubCategoryID { get; set; }

        public int OrderID { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<ImageList>? ImageLists { get; set; } = new List<ImageList>();
        public virtual ICollection<Favorite>? Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<CartDetail>? CartDetails { get; set; } = new List<CartDetail>();
        public virtual ICollection<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();
        public virtual ICollection<MouseDetail> MouseDetails { get; set; } = new List<MouseDetail>();
        public virtual ICollection<KeyboardDetail> KeyboardDetails { get; set; } = new List<KeyboardDetail>();

        // n - 1
        public virtual Sale Sale { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual Order Order { get; set; }
    }
}
