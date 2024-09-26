using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
    public class User : EntityBase
    {
        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng không được để trống")]
        public string RoleID { get; set; }
        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public UserStatus Status { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<Favorite>? Favorites { get; set; }
        public virtual ICollection<FeedBack>? FeedBacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        // 1 - 1
        public virtual Cart Cart { get; set; }
        public virtual Member Member { get; set; }

        // n - 1
        public virtual Role Role { get; set; }


    }
}
