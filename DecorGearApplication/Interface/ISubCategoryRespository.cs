using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface ISubCategoryRespository
    {
        Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<SubCategoryDto> GetSubCategoryeById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateSubCategory(SubCategoryDto request, CancellationToken cancellationToken);
        Task<bool> DeleteSubCategory(Guid id, CancellationToken cancellationToken);
    }
}
