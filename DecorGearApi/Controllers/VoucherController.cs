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
        [HttpGet("get-all-voucher")]
        public async Task<ActionResult<IEnumerable<VoucherDto>>> GetAllVoucher([FromQuery] VoucherSearch? voucherSearch, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepo.GetAllVoucher(voucherSearch, cancellationToken);
            return Ok(voucher);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDto>> GetByIdVoucher(int id, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepo.GetKeyVoucherById(new ViewVoucherRequest { VoucherID = id }, cancellationToken);
            return Ok(voucher);
        }
        [HttpPut]
        public async Task<ActionResult> PutVoucher([FromBody] UpdateVoucherRequest request, int id, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepo.UpdateVoucher(id, request, cancellationToken);
            return Ok(voucher);
        }
        [HttpPost]
        public async Task<ActionResult> PostVoucher([FromBody] CreateVoucherRequest request, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepo.CreateVoucher(request, cancellationToken);
            return Ok(voucher);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVoucher(int id, CancellationToken cancellationToken)
        {
            var voucher = await _voucherRepo.DeleteVoucher(new DeleteVoucherRequest { VoucherID = id }, cancellationToken);
            return Ok(voucher);
        }
    }
}