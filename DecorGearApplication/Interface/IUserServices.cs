using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IUserServices
    {
        Task<ErrorMessage> Register(User user, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken);
        Task<UserDto> GetUserById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateUser(UserUpdateRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken);
    }
}
