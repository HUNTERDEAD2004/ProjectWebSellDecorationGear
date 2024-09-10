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
        [Required]
        public Guid? RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }
        public string CreatedBy { get; set; } // Thuộc tính lưu ID của người tạo

        // cấu hình 1 - n 
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public async Task Create(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
