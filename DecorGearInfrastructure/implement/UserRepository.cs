using Application.DataTransferObj.User.Request;
using AutoMapper;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.User.Email;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using Ecommerce.Application.DataTransferObj.User.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class UserRepository : IUserRespository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;
        private readonly ITokenServices _tokenServices;
        private readonly IMailingServices _mailingServices;

        public UserRepository(AppDbContext db, IMapper map, ITokenServices tokenServices, IMailingServices mailingServices)
        {
            _db = db;
            _map = map;
            _tokenServices = tokenServices;
            _mailingServices = mailingServices;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _db.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _db.Users.AnyAsync(x => x.UserName == username);
        }
        public async Task<bool> PhoneExistsAsync(string phoneNumber)
        {
            return await _db.Users.AnyAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _db.Users.ToListAsync();

            return _map.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int id, CancellationToken cancellationToken)
        {
            var userById = await _db.Users.FindAsync(id, cancellationToken);
            return _map.Map<UserDto>(userById);
        }

        public async Task<ResponseDto<UserDto>> Register(UserCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Dữ liệu yêu cầu không được để trống.");

                if (string.IsNullOrWhiteSpace(request.Email) ||
                    string.IsNullOrWhiteSpace(request.UserName) ||
                    string.IsNullOrWhiteSpace(request.Password) ||
                    string.IsNullOrWhiteSpace(request.PhoneNumber))
                {
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Các trường không được để trống.");
                }


                if (await EmailExistsAsync(request.Email))
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Email đã tồn tại.");

                if (await UserExistsAsync(request.UserName))
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Username đã tồn tại!");

                if (await PhoneExistsAsync(request.PhoneNumber))
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Số điện thoại đã tồn tại.");

                var userRole = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == "User", cancellationToken);
                if (userRole == null)
                    return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Vai trò không tìm thấy!");


                var user = new User
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    UserName = request.UserName,
                    Password = Hash.HashPassword(request.Password),
                    Status = UserStatus.Active,
                    CreatedTime = DateTime.UtcNow,
                    RoleID = userRole.RoleID
                };

                await _db.Users.AddAsync(user, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                var subject = "Xác thực email";
                var verificationCode = new Random().Next(100000, 999999).ToString();
                await _mailingServices.SendEmailAsync(user.Email, subject,
                    $"Mã xác thực của bạn là: {verificationCode}");

                var verificationEntity = new VerificationCode
                {
                    Email = request.Email,
                    Code = verificationCode.ToString(),
                    ExpirationTime = DateTime.UtcNow.AddMinutes(2)
                };

                await _db.VerificationCodes.AddAsync(verificationEntity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return new ResponseDto<UserDto>
                {
                    Data = new UserDto
                    {
                        UserID = user.UserID,
                        Name = user.Name,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        UserName = user.UserName,
                        Status = user.Status,
                        CreatedTime = DateTime.UtcNow,
                        RoleId = user.RoleID,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Đăng ký thành công! Vui lòng kiểm tra email của bạn để nhận mã xác thực."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<UserDto>(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật cơ sở dữ liệu.");
            }
            catch (ArgumentException)
            {
                return new ResponseDto<UserDto>(StatusCodes.Status400BadRequest, "Tham số không hợp lệ.");
            }
            catch (Exception ex)
            {

                return new ResponseDto<UserDto>(StatusCodes.Status500InternalServerError, "Lỗi không xác định: " + ex.Message);
            }
        }

        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);
        }

        public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _db.Users.SingleOrDefaultAsync(u => u.UserID == id, cancellationToken);
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _db.Users.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phonenumber, CancellationToken cancellationToken)
        {
            return await _db.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phonenumber, cancellationToken);
        }

        public async Task SaveRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserID == userId);
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<string> GetRefreshTokenByUserIdAsync(int userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserID == userId);
            return user?.RefreshToken;
        }

        public async Task DeleteRefreshTokenAsync(int userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserID == userId);
            if (user != null)
            {
                user.RefreshToken = null;
                await _db.SaveChangesAsync();
            }
        }

        public async Task RemoveOldRefreshTokenAsync(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.RefreshToken = null;
                await _db.SaveChangesAsync();
            }
        }


        public async Task<ResponseDto<bool>> DeleteUser(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(request.UserId);

            if (user == null)
                return new ResponseDto<bool>(StatusCodes.Status404NotFound, "Người dùng không tồn tại");

            _db.Users.Remove(user);

            var isDeleted = await _db.SaveChangesAsync(cancellationToken) > 0;

            return isDeleted
                ? new ResponseDto<bool>(StatusCodes.Status200OK, "Xóa người dùng thành công.")
                : new ResponseDto<bool>(StatusCodes.Status500InternalServerError, "Có lỗi xảy ra khi xóa người dùng.");
        }

        public async Task<ResponseDto<bool>> VerifyCodeAsync(VerifyCodeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var email = request.Email;
                var code = request.Code;

                var verificationCode = await _db.VerificationCodes
                        .FirstOrDefaultAsync(vc => vc.Email == email && vc.Code == code, cancellationToken);

                if (verificationCode == null)
                    return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Mã xác thực không hợp lệ hoặc không tồn tại.");

                // Kiểm tra xem mã đã hết hạn chưa
                var timeRemaining = verificationCode.ExpirationTime - DateTime.UtcNow;
                if (timeRemaining <= TimeSpan.Zero)
                {
                    // Xóa mã xác thực nếu đã hết hạn
                    _db.VerificationCodes.Remove(verificationCode);
                    await _db.SaveChangesAsync(cancellationToken);
                    return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Mã xác thực đã hết hạn.");
                }

                _db.VerificationCodes.Remove(verificationCode);
                await _db.SaveChangesAsync(cancellationToken);


                return new ResponseDto<bool>(StatusCodes.Status200OK, "Xác thực thành công!");

            }
            catch (DbUpdateException)
            {
                return new ResponseDto<bool>(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật cơ sở dữ liệu.");
            }
            catch (ArgumentException)
            {
                return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Tham số không hợp lệ.");
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>(StatusCodes.Status500InternalServerError, "Lỗi không xác định: " + ex.Message);
            }
        }
        public async Task SaveVerificationCodeAsync(VerificationCodePw verificationCode, CancellationToken cancellationToken)
        {
            await _db.VerificationCodePws.AddAsync(verificationCode, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> GetUserByVerificationCodeAsync(string verificationCode, CancellationToken cancellationToken)
        {
            var verificationEntry = await _db.VerificationCodePws
                .FirstOrDefaultAsync(vc => vc.Code == verificationCode && vc.Expiration > DateTime.UtcNow, cancellationToken);

            if (verificationEntry == null)
            {
                return null;
            }

            // Tìm người dùng tương ứng với mã xác thực
            return await _db.Users.FindAsync(verificationEntry.UserId);
        }

        public async Task<bool> ValidateVerificationCodeAsync(string email, string code, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            if (user == null) return false;

            var verification = await _db.VerificationCodePws
                .FirstOrDefaultAsync(vc => vc.UserId == user.UserID && vc.Code == code && vc.Expiration > DateTime.UtcNow, cancellationToken);

            return verification != null;
        }

        public async Task<ResponseDto<bool>> ResendVerificationCodeAsync(string email, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
                if (user == null)
                    return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Email không tồn tại.");

                // Kiểm tra xem mã xác thực trước đó có tồn tại và còn hiệu lực không
                var existingCode = await _db.VerificationCodes
                    .FirstOrDefaultAsync(vc => vc.Email == email, cancellationToken);

                if (existingCode != null)
                {
                    // Nếu mã trước đó đã hết hạn, xóa mã cũ
                    if (existingCode.ExpirationTime <= DateTime.UtcNow)
                    {
                        _db.VerificationCodes.Remove(existingCode);
                        await _db.SaveChangesAsync(cancellationToken);
                    }
                    else
                    {
                        return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Mã xác thực còn hiệu lực. Vui lòng kiểm tra email.");
                    }
                }

                var newVerificationCode = new Random().Next(100000, 999999).ToString();

                var subject = "Xác thực email";
                await _mailingServices.SendEmailAsync(email, subject, $"Mã xác thực của bạn là: {newVerificationCode}");

                var verificationEntity = new VerificationCode
                {
                    Email = email,
                    Code = newVerificationCode,
                    ExpirationTime = DateTime.UtcNow.AddMinutes(2)
                };

                await _db.VerificationCodes.AddAsync(verificationEntity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return new ResponseDto<bool>(StatusCodes.Status200OK, "Mã xác thực mới đã được gửi đến email của bạn.");
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<bool>(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật cơ sở dữ liệu.");
            }
            catch (ArgumentException)
            {
                return new ResponseDto<bool>(StatusCodes.Status400BadRequest, "Tham số không hợp lệ.");
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>(StatusCodes.Status500InternalServerError, "Lỗi không xác định: " + ex.Message);
            }
        }

        public async Task<ResponseDto<UserDto>> UpdateUser(int id, UserUpdateRequest request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(id, cancellationToken);

            if (user == null)
                return new ResponseDto<UserDto>(StatusCodes.Status404NotFound, "Người dùng không tồn tại.");

            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.UserName = request.UserName;

            _db.Users.Update(user);
            await _db.SaveChangesAsync(cancellationToken);

            var userDto = new UserDto
            {
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserName = user.UserName
            };

            return new ResponseDto<UserDto>(StatusCodes.Status200OK, "Cập nhật người dùng thành công.", userDto);

        }
    }

}

