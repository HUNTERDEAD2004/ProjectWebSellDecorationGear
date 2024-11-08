using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement;

public class CartDetailRepository : ICartDetailRespository
{
    private readonly AppDbContext _context;

    public CartDetailRepository(AppDbContext context)
    {
        _context = new AppDbContext();
    }
    
    
    // Lấy chi tiết sản phẩm trong giỏ hàng
    public async Task<CartDetail> GetCartDetailByCartIdAndProductId(int cartId, int productId)
    {
        return await _context.CartDetails
            .Where(cd => cd.CartID == cartId && cd.ProductID == productId && !cd.Deleted)
            .FirstOrDefaultAsync();
    }

    // Tạo mới chi tiết giỏ hàng
    public async Task CreateAsync(CartDetail cartDetail)
    {
        await _context.CartDetails.AddAsync(cartDetail);
        await _context.SaveChangesAsync();
    }

    // Cập nhật chi tiết giỏ hàng
    public async Task UpdateAsync(CartDetail cartDetail)
    {
        _context.CartDetails.Update(cartDetail);
        await _context.SaveChangesAsync();
    }

    // Tính tổng số lượng sản phẩm trong giỏ hàng
    public async Task<int> GetTotalQuantity(int cartId)
    {
        return await _context.CartDetails
            .Where(cd => cd.CartID == cartId && !cd.Deleted)
            .SumAsync(cd => cd.Quantity);
    }

    // Tính tổng tiền trong giỏ hàng
    public async Task<double> GetTotalAmount(int cartId)
    {
        return await _context.CartDetails
            .Where(cd => cd.CartID == cartId && !cd.Deleted)
            .SumAsync(cd => cd.TotalPrice);
    }
    
}