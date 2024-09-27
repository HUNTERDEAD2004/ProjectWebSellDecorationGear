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
    public class ImageList : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageListID { get; set; }
        
        [Required]
        public string ProductID { get; set; }
        
        public List<string> ImagePath { get; set; }  

        public string Description { get; set; }

        //Khóa ngoại
        public virtual Product Product { get; set; }
    }
}
