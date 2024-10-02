using AutoMapper;
using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile() 
        {
            CreateMap<FavoriteDto, Favorite>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>();
        }
    }
}
