using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<CreateUpdateBrandRequest, Brand > ();
            CreateMap<ViewBrandRequest, Brand>();
            CreateMap<DeleteBrandRequest, Brand>();
        }
    }
}
