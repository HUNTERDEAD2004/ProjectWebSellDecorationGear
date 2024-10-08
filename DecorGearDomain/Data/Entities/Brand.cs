﻿using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class Brand : EntityBase
    {
        [Required]
        public string BrandID { get; set; }

        [Required(ErrorMessage = " Vui lòng nhập tên")]
        public string BrandName { get; set; }

        public string Description { get; set; }

        // Khóa ngoại

        public virtual ICollection<Product> Products { get; set; } = new List<Product>(); 
    }
}
