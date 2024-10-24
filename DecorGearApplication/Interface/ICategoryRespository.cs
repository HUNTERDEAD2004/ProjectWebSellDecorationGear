using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ICategoryRespository
    {
        Task<List<CategoryDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(int id, CancellationToken cancellationToken);
    }
}
