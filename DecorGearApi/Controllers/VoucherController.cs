using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRespository _voucherRepo;
        public VoucherController(IVoucherRespository voucherRespository)
        {
            _voucherRepo = voucherRespository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoucherDto>>> GetAllVoucher(CancellationToken cancellationToken)
        {
            {
                var voucher = await _voucherRepo.GetAllVoucher(cancellationToken);
                return Ok(voucher);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDto>> GetByIdVoucher(int id, CancellationToken cancellationToken)
        {
            var request = new ViewVoucherRequest { VoucherID = id };
            var voucher = await _voucherRepo.GetKeyVoucherById(request, cancellationToken); 

            if (voucher == null)
            {
                return NotFound();
            }

            return Ok(voucher);
        }
        [HttpPut]
        public async Task<IActionResult> PutVoucher([FromBody] UpdateVoucherRequest request, int id, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest("Invalid order request.");
            }
            else
            {
                var existingVoucher = await _voucherRepo.GetKeyVoucherById(new ViewVoucherRequest { VoucherID = id }, cancellationToken);

                if (existingVoucher == null)
                {
                    return NotFound("Order not found.");
                }
                else
                {
                    existingVoucher.VoucherName = request.VoucherName;
                    existingVoucher.VoucherPercent = request.VoucherPercent;
                    existingVoucher.expiry = request.expiry;
                    var result = await _voucherRepo.UpdateVoucher(existingVoucher, cancellationToken);

                    if (result == ErrorMessage.Successfull)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest("Failed to update order.");
                    }
                }
            }
        }
    }
}