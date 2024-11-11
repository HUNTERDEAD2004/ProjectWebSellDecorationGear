using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICategoryRespository
    {
        Task<List<CategoryDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<CategoryDto>> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteCategory(int id, CancellationToken cancellationToken);
    }
}
