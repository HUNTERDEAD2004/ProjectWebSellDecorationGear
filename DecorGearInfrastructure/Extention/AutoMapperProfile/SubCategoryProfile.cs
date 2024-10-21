using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<CreateSubCategoryRequest, SubCategory>();
            CreateMap<UpdateSubCategoryRequest, SubCategory>();
            CreateMap<DeleteSubCategoryRequest, SubCategory>();
            CreateMap<ViewSubCategoryRequest, SubCategory>();
        }
    }
}
