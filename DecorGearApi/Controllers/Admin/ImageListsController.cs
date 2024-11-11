using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ImageListsController : ControllerBase
    {
        private readonly IImageListRespository _res;
        private readonly IMapper _mapper;
        public ImageListsController(IImageListRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _res.GetAllImage(cancellationToken);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _res.GetImageById(id, cancellationToken);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateImageLists(CreateImageRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _res.CreateImage(request, cancellationToken);
            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("update")]
        public async Task<IActionResult> UpdateImageLists(int id, UpdateImageListRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy sản phẩm cần cập nhật theo ID
            var valueId = await GetById(id, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Gọi phương thức Update để lưu các thay đổi
            var result = await _res.UpdateImage(id, request, cancellationToken);

            // Trả về kết quả thành công với sản phẩm đã cập nhật
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteImageLists(int id, CancellationToken cancellationToken)
        {
            // Lấy sản phẩm cần xóa theo ID
            var valueId = await _res.GetImageById(id, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Gọi phương thức Delete để xóa sản phẩm
            await _res.DeleteImage(id, cancellationToken);

            // Trả về kết quả thành công với thông báo xác nhận        
            return Ok(valueId);
        }
    }
}
