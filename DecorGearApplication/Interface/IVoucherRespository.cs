using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IVoucherRespository
    {
        Task<List<VoucherDto>> GetAllVoucher(CancellationToken cancellationToken);
        Task<VoucherDto> GetKeyVoucherById(ViewVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateVoucher(VoucherDto request, CancellationToken cancellationToken);
        Task<bool> DeleteVoucher(DeleteVoucherRequest request, CancellationToken cancellationToken);
    }
}
