using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using Ecommerce.Application.DataTransferObj.User.Request;




namespace DecorGearApplication.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRespository _userRepository;

        public UserServices(IUserRespository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto<UserDto>> Register(UserCreateRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.Register(request, cancellationToken);
        }

        public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers(cancellationToken);
        }

        public async Task<UserDto> GetUserById(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(id, cancellationToken);
        }

        public async Task<ResponseDto<UserDto>> UpdateUser(int id, UserUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUser(id, request, cancellationToken);
        }

        public async Task<ResponseDto<bool>> DeleteUser(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUser(request, cancellationToken);
        }


    }
}
