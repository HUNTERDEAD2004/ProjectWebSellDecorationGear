using AutoMapper;
using DecorGearApplication.DataTransferObj.Role;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Pagination;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class RoleRepository : IRoleRespository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public RoleRepository(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public async Task<bool> CreateAsync(Role request, CancellationToken cancellationToken)
        {
            try
            {
                request.CreatedTime = DateTimeOffset.Now;
                await _db.Roles.AddAsync(request, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateDefaultRolesAsync(CancellationToken cancellationToken)
        {
            try
            {
                // Kiểm tra và thêm vai trò User nếu chưa tồn tại
                var userRole = await _db.Roles
                    .Where(r => r.RoleName == "User")
                    .FirstOrDefaultAsync(cancellationToken);

                if (userRole == null)
                {
                    // Tạo vai trò User nếu chưa tồn tại
                    userRole = new Role
                    {
                        RoleID = 3,
                        RoleName = "User",
                        CreatedTime = DateTimeOffset.UtcNow
                    };

                    await _db.Roles.AddAsync(userRole, cancellationToken);
                    await _db.SaveChangesAsync(cancellationToken);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<Role?> GetRoleById(int id, CancellationToken cancellationToken)
        {
            return await _db.Roles.FirstOrDefaultAsync(x => x.RoleID == id, cancellationToken);
        }

        public async Task<bool> DeleteAsync(int roleId, CancellationToken cancellationToken)
        {
            var role = await GetRoleById(roleId, cancellationToken);

            if (role == null)
            {
                return false;
            }

            role.DeletedTime = DateTimeOffset.Now;
            role.Deleted = true;

            _db.Roles.Update(role);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }

        
        public async Task<bool> UpdateAsync(Role request, CancellationToken cancellationToken)
        {
            var role = await GetRoleById(request.RoleID, cancellationToken);

            if (role == null)
            {
                return false;
            }

            role.RoleName = request.RoleName;
            role.ModifiedBy = request.ModifiedBy;

            _db.Roles.Update(role);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }

        public Task<PaginationResponse<RoleDto>> GetAllAsync(ViewRoleRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
