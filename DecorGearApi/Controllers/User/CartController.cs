using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] List<CreateCartDetailRequest> request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _cartService.AddProductsToCart(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
