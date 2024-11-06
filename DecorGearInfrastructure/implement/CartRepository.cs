using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

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
            using var transaction = await _dbcontext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var product = await _dbcontext.Products.FirstOrDefaultAsync(p => p.ProductID == request.ProductID, cancellationToken);
                if (product == null)
                {
                    return ErrorMessage.Failed;
                }

                if (product.Quantity < request.Quantity)
                {
                    return ErrorMessage.Failed;
                }

                var cart = await _dbcontext.Carts
                    .Include(c => c.CartDetails)
                    .FirstOrDefaultAsync(c => c.UserID == request.UserID, cancellationToken);

                if (cart == null)
                {
                    cart = new Cart { UserID = request.UserID, CartDetails = new List<CartDetail>() };
                    _dbcontext.Carts.Add(cart);
                }

                var existingCartDetail = cart.CartDetails.FirstOrDefault(item => item.ProductID == request.ProductID);
                if (existingCartDetail != null)
                {
                    existingCartDetail.Quantity += request.Quantity;
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

                product.Quantity -= request.Quantity;

                await _dbcontext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ErrorMessage.Failed;
            }
        }

        public Task<bool> DeleteCart(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken)
        {
            var result = await _dbcontext.Carts.ToListAsync(cancellationToken);
            return 
        }

        public Task<CartDto> GetCartById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
