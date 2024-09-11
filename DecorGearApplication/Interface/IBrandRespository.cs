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
    internal interface IBrandRespository
    {
        Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken);
        Task<BrandDto> GetBrandById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateBrand(CreateUpdateBrandRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateBrand(CreateUpdateBrandRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteBrand(DeleteBrandRequest request, CancellationToken cancellationToken);
    }
}
