using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class BrandRespository : IBrandRespository
    {
        public Task<ErrorMessage> CreateBrand(CreateUpdateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBrand(DeleteBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetBrandById(ViewBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateBrand(CreateUpdateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
