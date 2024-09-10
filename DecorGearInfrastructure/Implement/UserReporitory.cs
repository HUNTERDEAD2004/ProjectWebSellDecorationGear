using Application.DataTransferObj.User.Request;
using AutoMapper;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using Ecommerce.Application.DataTransferObj.User.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class UserReporitory : IUserServices
    {
        private readonly AppDbContext _dbContext;
        private readonly Role _role;
        private readonly IMapper _mapper;
        private bool isAdmin;

        public UserReporitory(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
     
        public bool EmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email); // Đúng kiểu dữ liệu là Users
        }

        public bool UserExists(string username)
        {
            return _dbContext.Users.Any(x => x.UserName == username); 
        }

        public async Task<ErrorMessage> Register(User user, CancellationToken cancellationToken)
        {
            try
            {
                // Kiểm tra nếu email hoặc username đã tồn tại
                if (EmailExists(user.Email) || UserExists(user.UserName))
                {
                    return ErrorMessage.Faild;
                }

                // Mã hóa mật khẩu và thiết lập các thuộc tính của người dùng
                user.Password = HashKey.EncryptPassword(user.Password, user.Password);
                user.Status = UserStatus.Active;
                user.CreatedTime = DateTimeOffset.Now;

                // Thêm người dùng vào cơ sở dữ liệu
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                // Tạo cart cho người dùng mới
                var cart = new DecorGearDomain.Data.Entities.Cart
                {
                    CreatedTime = DateTimeOffset.Now,
                    UserID = user.UserID, // Liên kết giỏ hàng với người dùng mới
                    TotalQuantity = 0,    // Giá trị mặc định hoặc tính toán sau
                    TotalAmount = 0m,     // Giá trị mặc định hoặc tính toán sau
                };

                await _dbContext.Carts.AddAsync(cart, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                // Xác định tên role dựa trên tham số isAdmin
                var roleName = isAdmin ? "Admin" : "User";

                // Tạo một role cho người dùng
                await _role.Create(new Role
                {
                    RoleID = Guid.NewGuid(), // Gán Guid vào RoleID
                    RoleName = roleName,
                    CreatedBy = user.UserID,
                }, cancellationToken);

                // tạo một tài khoản admin
                if (isAdmin)
                {
                    var adminUser = new User
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        Password = HashKey.EncryptPassword("YourSecurePassword", "YourSecurePassword"), // Mã hóa mật khẩu
                        Status = UserStatus.Active,
                        CreatedTime = DateTimeOffset.Now
                    };

                    await _dbContext.Users.AddAsync(adminUser, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    // Tạo role Admin cho tài khoản admin
                    await _role.Create(new Role
                    {
                        RoleID = Guid.NewGuid(),
                        RoleName = "Admin",
                        CreatedBy = adminUser.UserID
                    }, cancellationToken);
                }

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Faild;
            }
        }


        public async Task<ErrorMessage> UpdateUser(UserUpdateRequest userUpdateRequest, CancellationToken cancellationToken) 
        {
            // Tìm kiếm người dùng theo ID
            var user = await _dbContext.Users.FindAsync(userUpdateRequest.Id, cancellationToken); 

            // Kiểm tra nếu không tìm thấy người dùng
            if (user == null)
            {
                return ErrorMessage.Faild;
            }

            // Sử dụng AutoMapper để ánh xạ các thay đổi từ DTO sang thực thể User
            _mapper.Map(userUpdateRequest, user);

            // Cập nhật người dùng vào cơ sở dữ liệu
            _dbContext.Users.Update(user); 
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ErrorMessage.Successfull; 
        }

        async Task<List<UserDto>> IUserServices.GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var userById = await _dbContext.Users.FindAsync(id, cancellationToken);
            return _mapper.Map<UserDto>(userById); 
        }

        public async Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(id, cancellationToken);
            if (user != null)
            {
                _dbContext.Users.Remove(user); 
                await _dbContext.SaveChangesAsync(cancellationToken); 
                return true;
            }
            return false;
        }

      
    }
}
