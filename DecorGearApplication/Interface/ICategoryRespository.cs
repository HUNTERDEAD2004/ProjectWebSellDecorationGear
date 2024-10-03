using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface ICategoryRespository
    {
        Task<List<CategoryDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateCategory(CategoryDto request, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(Guid id, CancellationToken cancellationToken);
    }
}
