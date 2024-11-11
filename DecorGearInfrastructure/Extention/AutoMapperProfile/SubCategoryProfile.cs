using AutoMapper;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<CreateSubCategoryRequest, SubCategory>();
        }
    }
}
