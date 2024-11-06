using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeRepository _homeRepository;
        public HomeController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpGet("get-hot-product")]

        public async Task<ActionResult> GetHotProductAsync(CancellationToken cancellationToken)
        {
            var tophot = await _homeRepository.GetTopHotProductsAsync(5, cancellationToken);

            return Ok(tophot);
        }


        [HttpGet("get-top-view")]

        public async Task<ActionResult> GetTopView(CancellationToken cancellation)
        {
            var topview = await _homeRepository.GetTopViewedProductsAsync(5, cancellation);
            return Ok(topview);
        }
    }
}
