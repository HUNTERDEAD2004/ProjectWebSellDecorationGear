using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICartDetailRespository
    {
        Task<List<CartDetailDto>> GetAllCartDetai(CancellationToken cancellationToken);
        Task<CartDetailDto> GetCartDetailById(ViewCartRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateCartDetail(CreateCartDetailRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateCartDetail(UpdateCartDetailRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteUser(DeleteCartDetailRequest request, CancellationToken cancellationToken);
    }
}
