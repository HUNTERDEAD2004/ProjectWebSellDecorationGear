﻿using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class FeedBack : EntityBase
    {
        public Guid FeedBackID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public Guid ProductID { get; set; }

        [StringLength(500, ErrorMessage = "Bình luận không được vượt quá 500 ký tự")]
        public string Comment { get; set; }

        //Khóa ngoại
        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
