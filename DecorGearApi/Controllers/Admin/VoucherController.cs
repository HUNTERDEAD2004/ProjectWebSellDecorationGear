using AutoMapper;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DecorGearApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRespository _res;
        private readonly IMapper _map;

        public VoucherController(IVoucherRespository voucherRespository, IMapper mapper)
        {
            _map = mapper;
            _res = voucherRespository;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) 
        {
            var result = await _res.GetAllVoucher(cancellationToken);
            return Ok(result);
        }

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var keyResultValue = await _res.GetKeyVoucherById(id, cancellationToken);
            if (keyResultValue == null)
            {
                return NotFound($"Không tìm thấy Voucher với ID: {id}");
            }
            return Ok(keyResultValue);
        }

        [HttpPost("create-Voucher")]
        public async Task<IActionResult> CreateVouchers(CreateVoucherRequest request, CancellationToken cancellationToken)
        {
            var result = await _res.CreateVoucher(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut("update-Voucher")]
        public async Task<IActionResult> UpdateVouchers( int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var valueID = await _res.GetKeyVoucherById(id, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }

            var result = await _res.UpdateVoucher(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete-Voucher")]
        public async Task<IActionResult> DeleteVouchers(int id, CancellationToken cancellationToken)
        {
            // Không cần public ở đây, chỉ sử dụng var
            var valueID = await _res.GetKeyVoucherById(id, cancellationToken);

            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }


            // Gọi phương thức xoá
            var result = await _res.DeleteVoucher(id, cancellationToken);

            return Ok(result);
        }
    }
}
