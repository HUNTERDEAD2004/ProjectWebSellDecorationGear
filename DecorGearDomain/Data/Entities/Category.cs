using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class Category : EntityBase
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = " Vui lòng nhập tên")]
        public string CategoryName { get; set; }

        //Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
