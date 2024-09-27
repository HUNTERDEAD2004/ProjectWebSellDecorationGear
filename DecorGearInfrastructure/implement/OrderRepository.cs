using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
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
        public async Task<ErrorMessage> CreateOder(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Null;
            }
            else 
            {
                var newOder = new Order
                {
                    UserID = request.UserID,
                    VoucherID = request.VoucherID,
                    totalQuantity = request.totalQuantity,
                    totalPrice = (double)request.totalPrice,
                    paymentMethod = request.paymentMethod,
                    size = request.size.ToString(),
                    weight = request.weight,
                    OrderDate = request.OrderDate
                };
                await _dbcontext.Orders.AddAsync(newOder, cancellationToken);
                try
                {
                    await _dbcontext.SaveChangesAsync();
                    return ErrorMessage.Successfull;
                }
                catch (Exception)
                {
                    return ErrorMessage.Failed;
                }
            }
        }

        public async Task<bool> DeleteOder(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
             var order = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);
            if (order == null)
            {
                return false;
            }
            else 
            { 
                _dbcontext.Orders .Remove(order);
                await _dbcontext.SaveChangesAsync();    
                return true;
            }
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
                OrderDate = o.OrderDate,
                Status = o.Status,
            }).ToList();
        }

        public async Task<OderDto> GetKeyOderById(ViewOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);

            if (order == null)
            {
                return null;
            }

            return new OderDto
            {
                OderID = order.OrderID,
                UserID = order.UserID,
                totalQuantity = order.totalQuantity,
                totalPrice = (decimal)order.totalPrice,
                paymentMethod = order.paymentMethod,
                size = order.size,
                weight = (float)order.weight,
                OrderDate = order.OrderDate,
                Status = order.Status,
            };
        }

        public async Task<ErrorMessage> UpdateOder(OderDto request, CancellationToken cancellationToken)
        {
            var updateOrder = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);
            if(updateOrder == null)
            {
                return ErrorMessage.Failed;
            }
            else
            {
                updateOrder.UserID = request.UserID;
                updateOrder.VoucherID = request.VoucherID;
                updateOrder.totalQuantity = request.totalQuantity;
                updateOrder.totalPrice = (double)request.totalPrice;
                updateOrder.paymentMethod = request.paymentMethod;
                updateOrder.size = request.size.ToString();
                updateOrder.weight = request.weight;
                updateOrder.OrderDate = request.OrderDate;
                updateOrder.Status = request.Status;
                await _dbcontext.SaveChangesAsync();    
                return ErrorMessage.Successfull;
            }
        }
    }
}
