using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.ValueObj.Response;
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
        Task<CategoryDto> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<CategoryDto>> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteCategory(int id, CancellationToken cancellationToken);
    }
}
