using DecorGearApplication.DataTransferObj;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken);
        Task<CartDto> GetCartById(int id, CancellationToken cancellationToken);
        Task<bool> DeleteCart(int id, CancellationToken cancellationToken);
    }
}
