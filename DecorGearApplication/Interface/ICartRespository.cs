using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Cart;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken);
        Task<CartDto> GetCartById(int id, CancellationToken cancellationToken);
        Task<bool> DeleteCart(DeleteCartRequest request, CancellationToken cancellationToken);
    }
}
