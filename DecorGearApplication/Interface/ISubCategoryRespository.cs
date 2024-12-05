using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface ISubCategoryRespository
    {
        Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<SubCategoryDto> GetSubCategoryeById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<SubCategoryDto>> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<SubCategoryDto>> UpdateSubCategory(int id, UpdateSubCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteSubCategory(int id, CancellationToken cancellationToken);
    }
}
