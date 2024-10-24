using DecorGearApplication.DataTransferObj.Order;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IOderRespository
    {
        Task<IEnumerable<OderDto>> GetAllOder(CancellationToken cancellationToken);
        Task<OderDto> GetKeyOderById(ViewOrderRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateOder(CreateOrderRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateOder(OderDto request, CancellationToken cancellationToken);
        Task<bool> DeleteOder(DeleteOrderRequest request, CancellationToken cancellationToken);
    }
}
