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
        Task<List<OrderDto>> GetAllOder(CancellationToken cancellationToken);
        Task<OrderDto> GetKeyOderById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateOder(CreateOrderRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateOder(OrderDto request, CancellationToken cancellationToken);
        Task<bool> DeleteOder(int id, CancellationToken cancellationToken);
    }
}
