using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICartDetailRespository
    {
        Task<List<CartDetailDto>> GetAllCartDetai(CancellationToken cancellationToken);
        Task<CartDetailDto> GetCartDetailById (Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateCartDetail(CreateCartDetailRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateCartDetail (CartDetailDto request, CancellationToken cancellationToken);
        Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken);
    }
}
