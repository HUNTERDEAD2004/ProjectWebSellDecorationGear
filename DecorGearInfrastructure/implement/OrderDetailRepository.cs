using DecorGearApplication.DataTransferObj.OrderDetail;
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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _dbcontext;
        public OrderDetailRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<ErrorMessage> CreateOderDetail(OrderDetailDTO request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Null;
            }
            else
            {
                var newOderDetail = new OrderDetail
                {
                    OrderID = request.OrderID,  
                    ProductID = request.ProductID,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                };
                await _dbcontext.OrderDetails.AddAsync(newOderDetail);
                try
                {
                    await _dbcontext.SaveChangesAsync(cancellationToken);
                    return ErrorMessage.Successfull;
                }
                catch (Exception)
                {
                    return ErrorMessage.Failed;
                }
            }
        }

        public async Task<bool> DeleteOderDetail(OrderDetailDTO request, CancellationToken cancellationToken)
        {
            var id = await _dbcontext.OrderDetails.FirstOrDefaultAsync(o => o.OrderDetailId == request.OrderDetailId, cancellationToken);
            if (id == null)
            {
                return false;
            }
            else 
            {
                _dbcontext.OrderDetails.Remove(id); 
                await _dbcontext.SaveChangesAsync(cancellationToken);    
                return true;
            }
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetAllOderDetail(CancellationToken cancellationToken)
        {
            var orderDetail = await _dbcontext.OrderDetails.Include(o => o.Product).ToListAsync(cancellationToken);
            return orderDetail.Select(o => new OrderDetailDTO
            {
                OrderDetailId = o.OrderDetailId,
                ProductID = o.ProductID,
                OrderID = o.OrderID,
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice,
            }).ToList();

        }

        public async Task<OrderDetailDTO> GetByIdOderDetail(OrderDetailDTO request, CancellationToken cancellationToken)
        {
            var id = await _dbcontext.OrderDetails.FirstOrDefaultAsync(o => o.OrderDetailId == request.OrderDetailId, cancellationToken);

            if (id == null)
            {
                return null;
            }
            else
            {
                return new OrderDetailDTO
                {
                    OrderDetailId = id.OrderDetailId,
                    ProductID = id.ProductID,
                    OrderID = id.OrderID,
                    Quantity = id.Quantity,
                    UnitPrice = id.UnitPrice
                };
            }
        }


        public async Task<ErrorMessage> UpdateOderDetail(OrderDetailDTO request, CancellationToken cancellationToken)
        {
            var id = await _dbcontext.OrderDetails.FirstOrDefaultAsync(o => o.OrderDetailId == request.OrderDetailId, cancellationToken);
            if (id == null)
            {
                return ErrorMessage.Failed;
            }
            else
            {
                id.ProductID = request.ProductID;
                id.UnitPrice = request.UnitPrice;
                id.Quantity = request.Quantity;
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
        }
    }
}
