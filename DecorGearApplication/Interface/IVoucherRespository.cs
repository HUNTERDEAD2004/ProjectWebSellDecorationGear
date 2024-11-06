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
    public interface IVoucherRespository
    {
        Task<List<VoucherDto>> GetAllVoucher(CancellationToken cancellationToken);
        Task<VoucherDto> GetKeyVoucherById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateVoucher(int id, CancellationToken cancellationToken);
        Task<bool> DeleteVoucher(int id, CancellationToken cancellationToken);
    }
}
