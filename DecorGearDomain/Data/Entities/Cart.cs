﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecorGearDomain.Data.Base;

namespace DecorGearDomain.Data.Entities
{
    public class Cart : EntityBase
    {
        public int CartID { get; set; }

        [Required]
        public string UserID { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // 1 - 1
        public virtual User User { get; set; }
    }
}
