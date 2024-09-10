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
        [Required]
        public string ?UserID { get; set; }  

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9_]{5,20}$", ErrorMessage = "Username must be between 5 and 20 characters and contain only letters, numbers, and underscores.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Required]
        public string RoleID { get; set; }
        
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
