using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class CategoryRespository : ICategoryRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CategoryRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            try
            {

                var createCategory = _mapper.Map<Category>(request);

                await _appDbContext.Categories.AddAsync(createCategory, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Tạo thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi tạo cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.Categories.FindAsync(id, cancellationToken);
            if (keyResult != null)
            {
                _appDbContext.Categories.Remove(keyResult);
                _appDbContext.SaveChangesAsync();
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

        public async Task<List<CategoryDto>> GetAllCategory(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Categories.ToListAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(result);
        }

        public async Task<CategoryDto> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.Categories.FindAsync(id, cancellationToken);

            return _mapper.Map<CategoryDto>(keyResult);
        }

        public async Task<ResponseDto<CategoryDto>> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            try
            {
                var category = await _appDbContext.Categories.FindAsync(id);

                category.CategoryName = request.CategoryName;

                _appDbContext.Categories.Update(category);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<CategoryDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }
    }
}
