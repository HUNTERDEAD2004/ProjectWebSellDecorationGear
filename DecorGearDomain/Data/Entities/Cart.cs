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
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public Guid CartID { get; set; }

        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public Guid UserID { get; set; }


        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // 1 - 1
        public virtual User User { get; set; }
    }
}
