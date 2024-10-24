﻿using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class FeedBack : EntityBase
    {
        public int FeedBackID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        [StringLength(500, ErrorMessage = "Bình luận không được vượt quá 500 ký tự")]
        public string Comment { get; set; }


        //Khóa ngoại
        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
