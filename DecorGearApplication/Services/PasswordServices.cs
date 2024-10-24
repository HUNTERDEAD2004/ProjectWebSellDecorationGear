using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Password;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace DecorGearApplication.Services
{
    public class PasswordServices : IPasswordServices
    {
        private readonly IUserRespository _userRepository;
        private readonly IMailingServices _mailingServices;
        private readonly ITokenServices _tokenServices;

        public PasswordServices(IUserRespository userRepository, IMailingServices mailingServices, ITokenServices tokenServices)
        {
            _userRepository = userRepository;
            _mailingServices = mailingServices;
            _tokenServices = tokenServices;
        }

        public async Task<ResponseDto<ErrorMessage>> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken)
        {

            if (request.NewPassword != request.NewPasswordConFirm)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mật khẩu mới và mậy khảu xác nhận không khớp");

            var user = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);

            if (user == null)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Người dùng không tồn tại");

            if (!VerifyPassword(request.OldPassword, user.Password))
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mật khẩu cũ không đúng");

            var hashedPassword = HashPassword(request.NewPassword);

            user.Password = hashedPassword;
            await _userRepository.UpdateUserAsync(user, cancellationToken);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK, "Đặt lại mật khẩu thành công");

        }

        public async Task<ResponseDto<ErrorMessage>> ForgotPassword(ForgotPassword request, CancellationToken cancellationToken)
        {
            var userByEmail = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (userByEmail == null)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status404NotFound, "Tài khoản không tồn tại.");


            var verificationCode = new Random().Next(100000, 999999).ToString();

            await _mailingServices.SendEmailAsync(userByEmail.Email, "Mã xác thực để đặt lại mật khẩu",
                $"Mã xác thực của bạn là: {verificationCode}");

            var codeEntity = new VerificationCodePw
            {
                UserId = userByEmail.UserID,
                Code = verificationCode,
                CreatedAt = DateTime.UtcNow,
                Expiration = DateTime.UtcNow.AddMinutes(1)
            };

            await _userRepository.SaveVerificationCodeAsync(codeEntity, cancellationToken);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK, "Mã xác thực đã được gửi đến email của bạn.");
        }



        public async Task<ResponseDto<ErrorMessage>> ResetPassword(ResetPassword request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.VerificationCodePw))
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mã xác thực không hợp lệ.");


            if (string.IsNullOrEmpty(request.NewPassword) || string.IsNullOrEmpty(request.ConfirmPW))
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mật khẩu mới và xác nhận mật khẩu không được để trống.");


            if (request.NewPassword != request.ConfirmPW)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mật khẩu mới và xác nhận mật khẩu không khớp.");


            if (request.NewPassword.Length < 6)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "Mật khẩu phải có ít nhất 6 ký tự.");


            var user = await _userRepository.GetUserByVerificationCodeAsync(request.VerificationCodePw, cancellationToken);
            if (user == null)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status404NotFound, "Không tìm thấy người dùng với mã xác thực.");

            user.Password = HashPassword(request.NewPassword);

            try
            {
                await _userRepository.UpdateUserAsync(user, cancellationToken);
            }
            catch (Exception ex)
            {
                return new ResponseDto<ErrorMessage>(StatusCodes.Status500InternalServerError, $"Lỗi không xác định: {ex.Message}");
            }

            return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK, "Mật khẩu đã được cập nhật thành công.");
        }



        private const int HashSize = 32;

        // Mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        // Xác thực mật khẩu
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashOfInput = HashPassword(enteredPassword);
            return hashOfInput == storedHash;
        }

    }
}
