using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRespository _res;
        private readonly IMapper _mapper;
        public BrandController(IBrandRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _res.GetAllBrand(cancellationToken);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _res.GetBrandById(id, cancellationToken);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _res.CreateBrand(request, cancellationToken);
            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBrand(BrandDto request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy sản phẩm cần cập nhật theo ID
            var valueId = await _res.GetBrandById(request.BrandID, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Cập nhật các thuộc tính của sản phẩm

            valueId.BrandID = request.BrandID;
            valueId.BrandName  = request.BrandName;
            valueId.Description = request.Description;

            // Gọi phương thức Update để lưu các thay đổi
            var result = await _res.UpdateBrand(valueId, cancellationToken);

            // Trả về kết quả thành công với sản phẩm đã cập nhật
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBrand(int id, CancellationToken cancellationToken)
        {
            // Lấy sản phẩm cần xóa theo ID
            var valueId = await _res.GetBrandById(id, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Gọi phương thức Delete để xóa sản phẩm
            await _res.DeleteBrand(id, cancellationToken);

            // Trả về kết quả thành công với thông báo xác nhận        
            return Ok(valueId);
        }
    }
}
