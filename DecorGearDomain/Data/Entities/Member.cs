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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        public string UserID { get; set; } 
        
        public int Points { get; set; }

        public DateTime ExpiryDate { get; set; }

        // Khóa ngoại

        // 1 - 1
        public virtual User User { get; set; }
    }
}
