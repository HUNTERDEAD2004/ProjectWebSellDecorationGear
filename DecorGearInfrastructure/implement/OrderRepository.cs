using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class OrderRepository : IOderRespository
    {
        private readonly AppDbContext _dbcontext;
        public OrderRepository(AppDbContext dbContext)
        {
                _dbcontext = dbContext;
        }
        public Task<ErrorMessage> CreateOder(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOder(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OderDto>> GetAllOder(CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders.ToListAsync(cancellationToken);
            return order.Select(o => new OderDto
            {
                OderID = o.OrderID,
                UserID = o.UserID,
                VoucherID = o.VoucherID,
                totalQuantity = o.totalQuantity,
                totalPrice = (decimal)o.totalPrice,
                paymentMethod = o.paymentMethod,
                size = o.size,
                weight = (float)o.weight,
                OrderDate = o.OrderDate
            }).ToList();   
        }

        public async Task<OderDto> GetKeyOderById(ViewOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders
         .FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);

            if (order == null)
            {
                return null; 
            }

            return new OderDto
            {
                OderID = order.OrderID,
                UserID = order.UserID,
                totalQuantity = order.totalQuantity,
                totalPrice =(decimal)order.totalPrice,
                paymentMethod = order.paymentMethod,
                size = order.size,
                weight = (float)order.weight,
                OrderDate = order.OrderDate
            };
        }

        public Task<ErrorMessage> UpdateOder(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
