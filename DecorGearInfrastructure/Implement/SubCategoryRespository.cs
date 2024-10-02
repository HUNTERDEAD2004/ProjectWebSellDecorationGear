using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class SubCategoryRespository : ISubCategoryRespository
    {
        public Task<ErrorMessage> CreateSubCategory(CreateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubCategory(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoryDto> GetSubCategoryeById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateSubCategory(SubCategoryDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
