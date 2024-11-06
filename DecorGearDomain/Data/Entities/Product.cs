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
        public int ProductID { get; set; }

        public int? SaleID { get; set; }  // có thể có hoặc không

        [Required(ErrorMessage = "Không được để trống")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int SubCategoryID { get; set; }  

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không vượt quá 255 ký tự")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá tiền ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public double Price { get; set; }

        [Range(0,10000, ErrorMessage = "View không được vượt quá 10000 lượt xem")]
        public int View { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số nguyên dương")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Cân nặng phải lớn hơn 0kg")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        [StringLength(100, ErrorMessage = "Mô tả không được vượt quá 100 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(10, ErrorMessage = "Size được phụ thuộc vào cân nặng S(<=5) , M(>5<=15) , L(>15<=30) , (>30<=50)XL , (>50<=100)XXL")]
        public string Size { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Đơn vị dung lượng pin được dung ở đây là Miliample/Hour")]
        public int? BatteryCapacity { get; set; } // dung lượng pin

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<ImageList>? ImageLists { get; set; } = new List<ImageList>();
        public virtual ICollection<Favorite>? Favorites { get; set; } = new List<Favorite>();
        public virtual ICollection<CartDetail>? CartDetails { get; set; } = new List<CartDetail>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();
        public virtual ICollection<MouseDetail> MouseDetails { get; set; } = new List<MouseDetail>();
        public virtual ICollection<KeyboardDetail> KeyboardDetails { get; set; } = new List<KeyboardDetail>();

        // n - 1
        public virtual Sale Sale { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
