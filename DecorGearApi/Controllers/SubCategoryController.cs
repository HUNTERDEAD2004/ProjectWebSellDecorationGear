using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRespository _res;
        private readonly IMapper _mapper;
        public SubCategoryController(ISubCategoryRespository categoryRespository, IMapper mapper)
        {
            _res = categoryRespository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var resultValue = await _res.GetAllSubCategory(cancellationToken);
            return Ok(resultValue);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var keyResultValue = await _res.GetSubCategoryeById(id, cancellationToken);
            return Ok(keyResultValue);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = _res.CreateSubCategory(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSubCategory(SubCategoryDto request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var valueID = await _res.GetSubCategoryeById(request.CategoryID, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            valueID.SubCategoryID = request.SubCategoryID;
            valueID.SubCategoryName = request.SubCategoryName;
            valueID.CategoryID = request.CategoryID;

            var result = await _res.UpdateSubCategory(valueID, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var valueID = await _res.GetSubCategoryeById(id, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            await _res.DeleteSubCategory(id, cancellationToken);

            return Ok(valueID);
        }
    }
}
