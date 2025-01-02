using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class CartRepository : ICartRespository
    {
        private readonly AppDbContext _dbcontext;
        public CartRepository(AppDbContext appDbContext)
        {
            _dbcontext = appDbContext;
        }
        public async Task<ErrorMessage> AddProductToCart(CreateCartDetailRequest request, CancellationToken cancellationToken)
        {
            var cart = await _dbcontext.Carts.Include(c => c.CartDetails).FirstOrDefaultAsync(c => c.UserID == request.UserID, cancellationToken);
            if (cart == null)
            {
                cart = new Cart { UserID = request.UserID, CartDetails = new List<CartDetail>() };
                _dbcontext.Carts.Add(cart);
            }
            var existingCart = cart.CartDetails.FirstOrDefault(item => item.ProductID == request.ProductID);
            if (existingCart != null)
            {
                existingCart.Quantity += request.Quantity;
            }
            else
            {
                var newCartDetail = new CartDetail
                {
                    ProductID = request.ProductID,
                    Quantity = request.Quantity,
                    UnitPrice = (double)request.UnitPrice,
                };
                cart.CartDetails.Add(newCartDetail);
            }
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return ErrorMessage.Successfull;
        }

        public Task<bool> DeleteCart(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCartById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
