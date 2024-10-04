using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class BrandRespository : IBrandRespository
    {
        public Task<ErrorMessage> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBrand(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetBrandById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateBrand(BrandDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
