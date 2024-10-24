﻿using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class CategoryRespository : ICategoryRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CategoryRespository(AppDbContext appDbContext, IMapper mapper)
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

                await _appDbContext.Categories.AddAsync(createCategory, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteCategory(int id, CancellationToken cancellationToken)
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

        public async Task<CategoryDto> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.Categories.FindAsync(id, cancellationToken);

            return _mapper.Map<CategoryDto>(keyResult);
        }

        public async Task<ErrorMessage> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var category = await _appDbContext.Categories.FindAsync(id);

                category.CategoryName = request.CategoryName;

                _appDbContext.Categories.Update(category);

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
