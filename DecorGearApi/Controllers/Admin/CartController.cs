using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
   // [Authorize(Roles = "Admin")]
    public class CartController : ControllerBase
    {
      
       private readonly CartService _cartService;
       public CartController(CartService cartService)
       {
           _cartService = cartService;
       }

       [HttpPost("add-to-cart")]
       public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
       {
           var result = await _cartService.AddProductToCart(request);

           if (result)
           {
               return Ok("Sản phẩm đã được thêm vào giỏ hàng!");
           }

           return BadRequest("Thêm sản phẩm vào giỏ hàng thất bại!");
       }
    }
}

