using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Member
{
    public class MemberDto
    {
        public int MemberID { get; set; }

        public int? UserID { get; set; } 

        public int Points { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
