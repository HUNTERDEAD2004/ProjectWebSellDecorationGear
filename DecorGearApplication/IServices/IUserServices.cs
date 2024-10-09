using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Email;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.IServices
{
    public interface IUserServices
    {
        Task<ResponseDto<UserDto>> Register(UserCreateRequest request, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken);
        Task<UserDto> GetUserById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<UserDto>> UpdateUser(int id,UserUpdateRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteUser(int id, CancellationToken cancellationToken);
        Task VerifyCodeAsync(VerifyCodeRequest request, CancellationToken cancellationToken);
    }
}
