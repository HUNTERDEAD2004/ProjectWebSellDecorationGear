using Application.DataTransferObj.User.Request;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.ValueObj.Response;
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
        Task<BrandDto> GetBrandById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<BrandDto>> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<BrandDto>> UpdateBrand(int id, UpdateBrandRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteBrand(int id, CancellationToken cancellationToken);
    }
}
