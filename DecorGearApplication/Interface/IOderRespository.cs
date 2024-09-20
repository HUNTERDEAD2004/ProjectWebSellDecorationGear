using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IOderRespository


    {
        Task<IEnumerable<OderDto>> GetAllOder(CancellationToken cancellationToken);
        Task<OderDto> GetKeyOderById(ViewOrderRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateOder(CreateOrderRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateOder(UpdateOrderRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteOder(DeleteOrderRequest request, CancellationToken cancellationToken);
        
    }
}
