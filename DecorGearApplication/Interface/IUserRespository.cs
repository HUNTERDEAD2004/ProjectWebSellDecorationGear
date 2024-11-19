using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Email;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearDomain.Data.Entities;

namespace DecorGearApplication.Interface
{
    public interface IUserRespository
    {
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UserExistsAsync(string username);
        Task<bool> PhoneExistsAsync(string phoneNumber);
        Task<List<UserDto>> GetAllUsers(int pageNumber, int pageSize);
        Task<UserDto> GetUserById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<UserDto>> Register(UserCreateRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteUser(UserDeleteRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<UserDto>> UpdateUser(int id, UserUpdateRequest request, CancellationToken cancellationToken);
        Task UpdateUserAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);
        Task SaveRefreshTokenAsync(int userId, string refreshToken);
        Task<string> GetRefreshTokenByUserIdAsync(int userId);
        Task DeleteRefreshTokenAsync(int userId);
        Task RemoveOldRefreshTokenAsync(int userId);
        Task<ResponseDto<bool>> VerifyCodeAsync(VerifyCodeRequest request, CancellationToken cancellationToken);
        Task SaveVerificationCodeAsync(VerificationCodePw verificationCode, CancellationToken cancellationToken);
        Task<bool> ValidateVerificationCodeAsync(string email, string code, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> ResendVerificationCodeAsync(string email, CancellationToken cancellationToken);
        Task<User> GetUserByVerificationCodeAsync(string verificationCode, CancellationToken cancellationToken);
    }
}
