using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOderRespository _orderRepo;

        public OrdersController(IOderRespository oderRespository)
        {
            _orderRepo = oderRespository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OderDto>>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetAllOder(cancellationToken);
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OderDto>> GetByIdOrder(int id, CancellationToken cancellationToken)
        {
            var request = new ViewOrderRequest { OderID = id };
            var order = await _orderRepo.GetKeyOderById(request, cancellationToken);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var request = new DeleteOrderRequest { OderID = id };
            var result = await _orderRepo.DeleteOder(request, cancellationToken);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest("Invalid order request.");
            }

            var result = await _orderRepo.CreateOder(request, cancellationToken);

            if (result == ErrorMessage.Successfull)
            {
                return CreatedAtAction(nameof(CreateOrder), null);
            }
            else if (result == ErrorMessage.Null || result == ErrorMessage.Failed)
            {
                return BadRequest("Failed to create order.");
            }

            return StatusCode(500, "Internal server error.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOder([FromBody] UpdateOrderRequest request, int id, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest("Invalid order request.");
            }
            else
            {
                var existingOrder = await _orderRepo.GetKeyOderById(new ViewOrderRequest { OderID = id }, cancellationToken);

                if (existingOrder == null)
                {
                    return NotFound("Order not found.");
                }
                else
                {
                    existingOrder.totalQuantity = request.totalQuantity;
                    existingOrder.totalPrice = request.totalPrice;
                    existingOrder.paymentMethod = request.paymentMethod;
                    existingOrder.size = request.size.ToString();
                    existingOrder.weight = request.weight;
                    existingOrder.Status = request.Status;
                    var result = await _orderRepo.UpdateOder(existingOrder, cancellationToken);

                    if (result == ErrorMessage.Successfull)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest("Failed to update order.");
                    }
                }
            }
        }
    }
}
