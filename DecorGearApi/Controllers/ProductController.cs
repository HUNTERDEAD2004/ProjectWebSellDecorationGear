using AutoMapper;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRespository _Res;
        private readonly IMapper _Mapper;
        public ProductController(IProductRespository Respo,IMapper mapper)
        {
            _Res = Respo;
            _Mapper = mapper;
        }

        [HttpGet("Get-Product")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            await _Res.GetAllProduct(cancellationToken);
            return Ok();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
