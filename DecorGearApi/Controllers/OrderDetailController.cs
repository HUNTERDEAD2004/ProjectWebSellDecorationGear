using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.OrderDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.implement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepo;
        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepo = orderDetailRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetAllOrderDetail(CancellationToken cancellationToken)
        {
            var orderdetail = await _orderDetailRepo.GetAllOderDetail(cancellationToken);
            return Ok(orderdetail);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDTO>> GetByIdOrderDetail(int id, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepo.GetByIdOderDetail(new OrderDetailDTO { OrderDetailId = id }, cancellationToken);

            if (orderDetail == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy
            }

            return Ok(orderDetail); // Trả về 200 kèm theo dữ liệu
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailDTO request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _orderDetailRepo.CreateOderDetail(request, cancellationToken);

            if (result == ErrorMessage.Successfull)
            {
                return CreatedAtAction(nameof(CreateOrderDetail), null);
            }
            else if (result == ErrorMessage.Null || result == ErrorMessage.Failed)
            {
                return BadRequest("Failed to create OrderDetail.");
            }

            return StatusCode(500, "Internal server error.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id, CancellationToken cancellationToken)
        {
            var orderDetailDTO = new OrderDetailDTO { OrderDetailId = id };
            var result = await _orderDetailRepo.DeleteOderDetail(orderDetailDTO, cancellationToken);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
