using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Password;
using DecorGearDomain.Enum;

namespace DecorGearApplication.IServices
{
    public interface IPasswordServices
    {

        Task<ResponseDto<ErrorMessage>> ForgotPassword(ForgotPassword request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> ResetPassword(ResetPassword request, CancellationToken cancellationToken);

    }
}
