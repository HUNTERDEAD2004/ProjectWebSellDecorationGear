using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace DecorGearApi.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class KeyBoardController : ControllerBase
    {
        private readonly IKeyboardRespository _res;
        private readonly IMapper _mapper;
        public KeyBoardController(IKeyboardRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }


        // API lấy toàn bộ thông tin
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]ViewKeyBoardsRequest? request, CancellationToken cancellationToken)
        {
            var result = await _res.GetAllKeyBoard(request,cancellationToken);
            return Ok(result);
        }

        // API lấy thông tin theo id
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _res.GetKeyBoardById(id, cancellationToken);
            return Ok(result);
        }

        // API tạo chi tiêt bàn phím
        [HttpPost("create")]
        public async Task<IActionResult> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _res.CreateKeyBoard(request, cancellationToken);
            return Ok(result);
        }

        // API sửa chi tiêt bàn phím
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(int id,UpdateKeyBoardDetails request, CancellationToken cancellationToken)
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
            var result = await _res.UpdateKeyBoard(id,request, cancellationToken);

            // Trả về kết quả thành công với sản phẩm đã cập nhật
            return Ok(result);
        }

        // API xóa chi tiêt bàn phím
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            // Lấy sản phẩm cần xóa theo ID
            var valueId = await _res.GetKeyBoardById(id, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Gọi phương thức Delete để xóa sản phẩm
            await _res.DeleteKeyBoard(id, cancellationToken);

            // Trả về kết quả thành công với thông báo xác nhận        
            return Ok(valueId);
        }
    }
}
