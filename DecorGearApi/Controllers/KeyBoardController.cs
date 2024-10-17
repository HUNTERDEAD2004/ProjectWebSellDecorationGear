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
    [Route("api/[controller]")]
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _res.GetAllKeyBoard(cancellationToken);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _res.GetKeyBoardById(id, cancellationToken);
            return Ok(result);
        }

        // POST api/<ProductController>
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

        // PUT api/<ProductController>/5
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(KeyBoardDetailsDto request, CancellationToken cancellationToken)
        {
            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy sản phẩm cần cập nhật theo ID
            var valueId = await _res.GetKeyBoardById(request.KeyboardDetailID, cancellationToken);
            if (valueId == null)
            {
                return NotFound("Không có giá trị ID");
            }

            // Cập nhật các thuộc tính của sản phẩm
            
            valueId.KeyboardDetailID = request.KeyboardDetailID;
            valueId.ProductID = request.ProductID;
            valueId.KeycapMaterial = request.KeycapMaterial;
            valueId.Case = request.Case;
            valueId.Color = request.Color;
            valueId.Layout = request.Layout;
            valueId.Led = request.Led;
            valueId.PCB = request.PCB;
            valueId.SS = request.SS;
            valueId.Stabilizes = request.Stabilizes;
            valueId.Switch = request.Switch;
            valueId.SwitchLife = request.SwitchLife;
            valueId.SwitchMaterial = request.SwitchMaterial;

            // Gọi phương thức Update để lưu các thay đổi
            var result = await _res.UpdateKeyBoard(valueId, cancellationToken);

            // Trả về kết quả thành công với sản phẩm đã cập nhật
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
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
