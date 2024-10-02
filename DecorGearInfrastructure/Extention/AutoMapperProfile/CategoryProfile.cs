﻿using AutoMapper; 
using DecorGearApplication.DataTransferObj.Category; 
using DecorGearDomain.Data.Entities; 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>();
        }
    }
}
