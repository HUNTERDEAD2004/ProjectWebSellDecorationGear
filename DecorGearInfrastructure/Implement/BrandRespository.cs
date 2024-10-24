using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class BrandRespository : IBrandRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public BrandRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ErrorMessage> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createBrand = _mapper.Map<Brand>(request);

                await _appDbContext.Brands.AddAsync(createBrand, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteBrand(int id, CancellationToken cancellationToken)
        {
            var deleteBrand = await _appDbContext.Brands.FindAsync(id, cancellationToken);
            if (deleteBrand != null)
            {
                _appDbContext.Brands.Remove(deleteBrand);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<BrandDto>> GetAllBrand(CancellationToken cancellationToken)
        {
            var brands = await _appDbContext.Brands.ToListAsync(cancellationToken);

            return _mapper.Map<List<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetBrandById(int id, CancellationToken cancellationToken)
        {
            var brandIds = await _appDbContext.Brands.FindAsync(id, cancellationToken);

            return _mapper.Map<BrandDto>(brandIds);
        }

        public async Task<ErrorMessage> UpdateBrand(int id, UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var brand = await _appDbContext.Brands.FindAsync(id, cancellationToken);

                brand.BrandName = request.BrandName;
                brand.Description = request.Description;

                _appDbContext.Brands.Update(brand);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
