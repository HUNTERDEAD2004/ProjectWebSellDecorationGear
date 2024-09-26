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
    public class Favorite : EntityBase
    {
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public int FavoriteID { get; set; }

        [Required(ErrorMessage = "UserID không được để trống")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string ProductID { get; set; }

        // Khóa ngoại
        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
