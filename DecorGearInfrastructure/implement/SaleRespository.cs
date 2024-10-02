using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class SaleRespository : ISaleRespository
    {
        public Task<ErrorMessage> CreateSale(CreateSaleRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSale(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SaleDto>> GetAllSale(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SaleDto> GetKeySaleById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateSale(SaleDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
