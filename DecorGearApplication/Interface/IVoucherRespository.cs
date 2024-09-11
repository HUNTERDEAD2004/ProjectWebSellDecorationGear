using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    internal interface IVoucherRespository
    {
        Task<List<VoucherDto>> GetAllVoucher(CancellationToken cancellationToken);
        Task<VoucherDto> GetKeyVoucherById(ViewVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateVoucher(UpdateVoucherRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteVoucher(DeleteVoucherRequest request, CancellationToken cancellationToken);
    }
}
