﻿using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class SubCategory : EntityBase
    {
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public int CategoryID { get; set; }
        // Khóa ngoại

        // n - 1
        public virtual Category Category { get; set; }

        // 1 - n
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
