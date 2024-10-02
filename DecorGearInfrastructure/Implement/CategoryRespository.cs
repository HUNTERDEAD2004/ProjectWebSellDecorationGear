using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class CategoryRespository : ICategoryRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CategoryRespository(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ErrorMessage> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            try
            {

                var createCategory = _mapper.Map<Category>(request);

                createCategory.CategoryID = Guid.NewGuid();

                await _appDbContext.Categories.AddAsync(createCategory,cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteCategory(string id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.Categories.FindAsync(id, cancellationToken);
            if (keyResult != null)
            {
                _appDbContext.Categories.Remove(keyResult);
                _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CategoryDto>> GetAllCategory(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Categories.ToListAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(result);
        }

        public async Task<CategoryDto> GetCategoryById(string id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.Categories.FindAsync(id,cancellationToken);

            return _mapper.Map<CategoryDto>(keyResult);
        }

        public async Task<ErrorMessage> UpdateCategory(CategoryDto request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                return ErrorMessage.Failed;
            }
            if (await _appDbContext.Categories.AnyAsync(a => a.CategoryID == request.CategoryID))
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var updateCategory = new Category
                {
                    CategoryID = request.CategoryID,
                    CategoryName = request.CategoryName                   
                };

                 _appDbContext.Categories.Update(updateCategory);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
