﻿using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class Sale : EntityBase
    { 
        public int SaleID { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập tên")]
        public string  SaleName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm giá")]
        [Range(0, 100, ErrorMessage =("Phần trăm giảm giá không hợp lệ"))]
        public int SalePercent { get; set; }

        public EntityStatus Status { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
