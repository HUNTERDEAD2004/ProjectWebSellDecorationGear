using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IBrandRespository
    {
        Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken);
        Task<BrandDto> GetBrandById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateBrand(BrandDto request, CancellationToken cancellationToken);
        Task<bool> DeleteBrand(Guid id, CancellationToken cancellationToken);
    }
}
