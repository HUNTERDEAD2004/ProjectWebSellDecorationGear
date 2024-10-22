using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        private readonly IMouseRespository _res;
        private readonly IMapper _mapper;
        public MouseController(IMouseRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _res.GetAllMouse(cancellationToken);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _res.GetMouseById(id, cancellationToken);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _res.CreateMouse(request, cancellationToken);
            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMouse(int id,UpdateMouseRequest request, CancellationToken cancellationToken)
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
            var result = await _res.UpdateMouse(id,request, cancellationToken);

            // Trả về kết quả thành công với sản phẩm đã cập nhật
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMouse(int id, CancellationToken cancellationToken)
        {
            // Lấy sản phẩm cần xóa theo ID
            var valueId = await _res.GetMouseById(id, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Gọi phương thức Delete để xóa sản phẩm
            await _res.DeleteMouse(id, cancellationToken);

            // Trả về kết quả thành công với thông báo xác nhận        
            return Ok(valueId);
        }
    }
}
