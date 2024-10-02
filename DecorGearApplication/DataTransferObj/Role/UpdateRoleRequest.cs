using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Role
{
    public class UpdateRoleRequest
    {
        public Guid RoleID { get; set; }

        public string RoleName { get; set; }

        public string UserID { get; set; }
    }
}
