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
    public class FeedBack : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedBackID { get; set; }

        [Required]
        public string UserID { get; set; }
        
        [Required]
        public string ProductID { get; set; }

        public string Comment { get; set; }

        //Khóa ngoại
        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
