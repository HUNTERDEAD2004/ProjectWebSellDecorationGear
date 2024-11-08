using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class CartRepository : ICartRespository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }
        // Lấy giỏ hàng của người dùng theo UserID
        public async Task<Cart> GetCartByUserId(int userId)
        {
            return await _context.Carts
                .Where(c => c.UserID == userId && !c.Deleted)
                .FirstOrDefaultAsync();
        }

        // Tạo mới giỏ hàng
        public async Task CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        // Cập nhật giỏ hàng
        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

    }
}
