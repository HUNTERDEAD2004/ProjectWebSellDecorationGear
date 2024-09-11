using DecorGearApplication.ValueObj.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Role
{
    public class ViewRoleRequest : PaginationRequest
    {
        public string ?SearchName {  get; set; }
    }
}
