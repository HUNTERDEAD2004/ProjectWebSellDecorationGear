﻿using DecorGearApplication.DataTransferObj.Sale;
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
        Task<VoucherDto> GetKeyVoucherById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateVoucher (CreateVoucherRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateVoucher (VoucherDto request, CancellationToken cancellationToken);
        Task<bool> DeleteVoucher(Guid id, CancellationToken cancellationToken);
    }
}
