using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.DataTransferObj.SubCategory;
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
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class SubCategoryRespository : ISubCategoryRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public SubCategoryRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<SubCategoryDto>> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createSubCategory = _mapper.Map<SubCategory>(request);

                await _appDbContext.SubCategories.AddAsync(createSubCategory, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tạo thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi tạo cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteSubCategory(int id, CancellationToken cancellationToken)
        {
            var deleteSubCategory = await _appDbContext.SubCategories.FindAsync(id, cancellationToken);
            if (deleteSubCategory != null)
            {
                _appDbContext.SubCategories.Remove(deleteSubCategory);
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

        public async Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            var subCategory = await _appDbContext.SubCategories.ToListAsync(cancellationToken);

            return _mapper.Map<List<SubCategoryDto>>(subCategory);
        }

        public async Task<SubCategoryDto> GetSubCategoryeById(int id, CancellationToken cancellationToken)
        {
            var subCategoryIds = await _appDbContext.SubCategories.FindAsync(id, cancellationToken);

            return _mapper.Map<SubCategoryDto>(subCategoryIds);
        }

        public async Task<ResponseDto<SubCategoryDto>> UpdateSubCategory(int id,UpdateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var subCategory = await _appDbContext.SubCategories.FindAsync(id,cancellationToken);

                subCategory.SubCategoryName = request.SubCategoryName;
                subCategory.CategoryID = request.CategoryID;

                _appDbContext.SubCategories.Update(subCategory);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cập nhật thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<SubCategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }
    }
}
