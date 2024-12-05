using DecorGearApplication.DataTransferObj.Role;
using DecorGearApplication.ValueObj.Pagination;
using DecorGearDomain.Data.Entities;

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
