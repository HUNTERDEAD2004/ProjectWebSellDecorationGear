using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRespository _res;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRespository categoryRespository,IMapper mapper)
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
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var keyResultValue = await _res.GetCategoryById(id,cancellationToken);
            return Ok(keyResultValue);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = _res.CreateCategory(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(CategoryDto request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var valueID = await _res.GetCategoryById(request.CategoryID, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            valueID.CategoryID = request.CategoryID;
            valueID.CategoryName = request.CategoryName;

            var result = await _res.UpdateCategory(valueID,cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(string id,CancellationToken cancellationToken)
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
