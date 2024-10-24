using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Role
{
    public class DeleteRoleRequest
    {
        public int RoleID { get; set; }

        public int UserID { get; set; }
    }
}
