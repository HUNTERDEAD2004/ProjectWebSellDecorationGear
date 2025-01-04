using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.Voucher;

using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IVoucherRespository
    {
        Task<List<VoucherDto>> GetAllVoucher(VoucherSearch? voucherSearch, CancellationToken cancellationToken);
        Task<ResponseDto<VoucherDto>> GetKeyVoucherById(ViewVoucherRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<Voucher>> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<Voucher>> UpdateVoucher(int Id, UpdateVoucherRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<Voucher>> DeleteVoucher(DeleteVoucherRequest request, CancellationToken cancellationToken);
    }
}
