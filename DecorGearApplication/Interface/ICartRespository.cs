using DecorGearApplication.DataTransferObj;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken);
        Task<CartDto> GetCartById(Guid id, CancellationToken cancellationToken);
        Task<bool> DeleteCart(Guid id, CancellationToken cancellationToken);
    }
}
