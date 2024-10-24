using AutoMapper;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ErrorMessage> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createSubCategory = _mapper.Map<SubCategory>(request);

                await _appDbContext.SubCategories.AddAsync(createSubCategory, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteSubCategory(int id, CancellationToken cancellationToken)
        {
            var deleteSubCategory = await _appDbContext.SubCategories.FindAsync(id, cancellationToken);
            if (deleteSubCategory != null)
            {
                _appDbContext.SubCategories.Remove(deleteSubCategory);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
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

        public async Task<ErrorMessage> UpdateSubCategory(int id, UpdateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var subCategory = await _appDbContext.SubCategories.FindAsync(id, cancellationToken);

                subCategory.SubCategoryName = request.SubCategoryName;
                subCategory.CategoryID = request.CategoryID;

                _appDbContext.SubCategories.Update(subCategory);

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
