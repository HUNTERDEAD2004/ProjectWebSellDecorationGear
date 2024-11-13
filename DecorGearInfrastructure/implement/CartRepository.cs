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


        public Task CreateAsync(Cart cart, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Cart cart, CancellationToken cancellationToken)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            var existingCart = await _context.Carts.FindAsync(cart.CartID);
            if (existingCart != null)
            {
                existingCart.TotalQuantity = cart.TotalQuantity;
                existingCart.TotalAmount = cart.TotalAmount;
                existingCart.CartDetails = cart.CartDetails;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Cart not found.");
            }
        }
    }
}
