using DecorGearApplication.DataTransferObj.Role;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.ValueObj.Pagination;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IRoleRespository
    {
        Task<PaginationResponse<RoleDto>> GetAllAsync(ViewRoleRequest request, CancellationToken cancellationToken);
        Task<bool> CreateAsync(Role request, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Role request, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int roleId, CancellationToken cancellationToken);
    }
}
