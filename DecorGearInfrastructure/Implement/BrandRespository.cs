using Application.DataTransferObj.User.Request;
using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<ResponseDto<BrandDto>> CreateBrand(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createBrand = _mapper.Map<Brand>(request);

                await _appDbContext.Brands.AddAsync(createBrand, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Tạo thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi tạo cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteBrand(int id, CancellationToken cancellationToken)
        {
            var deleteBrand = await _appDbContext.Brands.FindAsync(id, cancellationToken);
            if (deleteBrand != null)
            {
                _appDbContext.Brands.Remove(deleteBrand);
                _appDbContext.SaveChanges();
                return new ResponseDto<bool>
                {
                    DataResponse = true,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công."
                };
            }
            return new ResponseDto<bool>
            {
                DataResponse = false,
                Status = StatusCodes.Status400BadRequest,
                Message = "Sửa thất bại."
            };
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

        public async Task<ResponseDto<BrandDto>> UpdateBrand(int id, UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var brand = await _appDbContext.Brands.FindAsync(id, cancellationToken);

                brand.BrandName = request.BrandName;
                brand.Description = request.Description;

                _appDbContext.Brands.Update(brand);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Cật nhật thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<BrandDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }
    }
}
