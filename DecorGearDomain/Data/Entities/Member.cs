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
    public class Member : EntityBase
    {
        [Required(ErrorMessage = "Không được để trống")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string? UserID { get; set; } // có thể có hoặc không 
        [Required(ErrorMessage = "Không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số dương")]
        public int Points { get; set; }
        [Required(ErrorMessage = "Không được để trống.")]
        public DateTime ExpiryDate { get; set; }

        // Khóa ngoại

        // 1 - 1
        public virtual User User { get; set; }
    }
}
