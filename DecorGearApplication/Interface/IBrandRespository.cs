﻿using DecorGearApplication.DataTransferObj.Brand;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IBrandRespository
    {
        Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken);
        Task<BrandDto> GetBrandById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateBrand(int id, UpdateBrandRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteBrand(int id, CancellationToken cancellationToken);
    }
}
