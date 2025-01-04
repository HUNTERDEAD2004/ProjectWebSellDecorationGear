using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.OrderDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

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

            var newOder = new Order
            {
                UserID = request.UserID,
                VoucherID = request.VoucherID,
                totalQuantity = request.totalQuantity,
                totalPrice = ((double)request.totalPrice),
                paymentMethod = request.paymentMethod,
                size = request.size.ToString(),
                weight = request.weight,
                OrderDate = request.OrderDate
            };

            await _dbcontext.Orders.AddAsync(newOder, cancellationToken);

            try
            {
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }


        public async Task<bool> DeleteOder(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            // Tìm hóa đơn cần xóa
            var order = await _dbcontext.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);

            if (order == null)
            {
                return false;
            }

            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                _dbcontext.OrderDetails.RemoveRange(order.OrderDetails);
            }

            // Xóa hóa đơn chính
            _dbcontext.Orders.Remove(order);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<OderDto>> GetAllOder(CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders.Include(o => o.OrderDetails).Include(x => x.User).ToListAsync(cancellationToken);
            return order.Select(o => new OderDto
            {
                OderID = o.OrderID,

                UserID = o.UserID,
                UserName = o.User.Name,
                VoucherID = o.VoucherID,
                totalQuantity = o.OrderDetails.Sum(od => od.Quantity),
                totalPrice = (decimal)o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity),
                paymentMethod = o.paymentMethod,
                size = o.size,
                weight = (float)o.weight,
                OrderDate = o.OrderDate,
                Status = o.Status,

                orderDetailDTOs = o.OrderDetails.Select(od => new OrderDetailDTO
                {
                    OrderDetailId = od.OrderDetailId,
                    ProductID = od.ProductID,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity
                }).ToList(),

            }).ToList();
        }

        public async Task<OderDto> GetKeyOderById(ViewOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);

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

                orderDetailDTOs = order.OrderDetails.Select(od => new OrderDetailDTO
                {
                    OrderDetailId = od.OrderDetailId,
                    ProductID = od.ProductID,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity
                }).ToList(),
            };
        }

        public async Task<ErrorMessage> UpdateOder(OderDto request, CancellationToken cancellationToken)
        {
            var updateOrder = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OderID, cancellationToken);
            if (updateOrder == null)
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
                updateOrder.OrderStatus = request.OrderStatus;
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
        }
    }
}
