using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DecorGearDomain.Data.Entities
{
    public class Role : EntityBase
    {
        public int RoleID { get; set; }

        [Required]
        public string? RoleName { get; set; }

        // cấu hình 1 - n 
        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
