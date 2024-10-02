using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
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

namespace DecorGearInfrastructure.implement
{
    public class BrandRespository : IBrandRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public BrandRespository(AppDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }
        public async Task<ErrorMessage> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            //Thêm thương hiệu mới
            try
            {
                var createBrand = _mapper.Map<Brand>(request);

                createBrand.BrandID = Guid.NewGuid();

                await _appDbContext.Brands.AddAsync(createBrand, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteBrand(string id, CancellationToken cancellationToken)
        {
            var deleteBrand = await _appDbContext.Brands.FindAsync(id,cancellationToken);
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
            var brand = await _appDbContext.Brands.ToListAsync(cancellationToken);

            return _mapper.Map<List<BrandDto>>(brand);
        }

        public async Task<BrandDto> GetBrandById(string id, CancellationToken cancellationToken)
        {
            var brandIds = await _appDbContext.Brands.FindAsync(id,cancellationToken);

            return _mapper.Map<BrandDto>(brandIds);
        }

        public async Task<ErrorMessage> UpdateBrand(BrandDto request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            // Kiểm tra xem BrandID đã tồn tại chưa 
            if (await _appDbContext.Brands.AnyAsync(x => x.BrandID == request.BrandID, cancellationToken))
            {
                return ErrorMessage.Failed;
            }

            // Cập Nhật Thương hiệu
            try
            {
                var updateBrand = new Brand
                {
                    BrandID = request.BrandID,
                    BrandName = request.BrandName,
                    Description = request.Description,
                };

                _appDbContext.Brands.Update(updateBrand);

                await _appDbContext.SaveChangesAsync();

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
