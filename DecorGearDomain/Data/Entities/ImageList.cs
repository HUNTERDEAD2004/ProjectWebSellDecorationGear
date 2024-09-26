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
        public Guid ImageListID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public List<string> ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string Description { get; set; }
        //Khóa ngoại
        public virtual Product Product { get; set; }
    }
}
