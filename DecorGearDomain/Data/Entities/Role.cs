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
    public class Role : EntityBase
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string RoleID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự")]
        public string RoleName { get; set; }

        // cấu hình 1 - n 
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
