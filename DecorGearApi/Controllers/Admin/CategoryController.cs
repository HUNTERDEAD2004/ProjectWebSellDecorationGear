using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRespository _res;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _res = categoryRespository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var resultValue = await _res.GetAllCategory(cancellationToken);
            return Ok(resultValue);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var keyResultValue = await _res.GetCategoryById(id, cancellationToken);
            return Ok(keyResultValue);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _res.CreateCategory(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var valueID = await GetById(id, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            var result = await _res.UpdateCategory(id, request, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var valueID = await _res.GetCategoryById(id, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            await _res.DeleteCategory(id, cancellationToken);

            return Ok(valueID);
        }
    }
}
