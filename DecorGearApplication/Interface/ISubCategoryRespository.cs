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
    internal interface ISubCategoryRespository
    {
        Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<SubCategoryDto> GetSubCategoryeById(ViewSubCategoryRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateSubCategory(UpdateSubCategoryRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteSubCategory(DeleteSubCategoryRequest request, CancellationToken cancellationToken);
    }
}
