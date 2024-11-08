using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICartDetailRespository
    {
        Task<CartDetail> GetCartDetailByCartIdAndProductId(int cartId, int productId);
        Task CreateAsync(CartDetail cartDetail);
        Task UpdateAsync(CartDetail cartDetail);
        Task<int> GetTotalQuantity(int cartId);
        Task<double> GetTotalAmount(int cartId);
    }
}
