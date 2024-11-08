using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task CreateAsync(Cart cart);
        Task UpdateAsync(Cart cart);
    }
}
