using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<ViewCategoryRequest, Category>();
        }
    }
}
