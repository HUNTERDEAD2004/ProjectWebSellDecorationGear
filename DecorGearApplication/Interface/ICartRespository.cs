using DecorGearDomain.Data.Entities;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task CreateAsync(Cart cart, CancellationToken cancellationToken);
        Task UpdateAsync(Cart cart, CancellationToken cancellationToken);
    }
}
