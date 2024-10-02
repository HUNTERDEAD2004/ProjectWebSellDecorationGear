﻿using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface ISaleRespository
    {
        Task<List<SaleDto>> GetAllSale(CancellationToken cancellationToken);
        Task<SaleDto> GetKeySaleById (Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateSale (CreateSaleRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateSale (SaleDto request, CancellationToken cancellationToken);
        Task<bool> DeleteSale(Guid id, CancellationToken cancellationToken);
    }
}
