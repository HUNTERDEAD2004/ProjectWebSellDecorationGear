using AutoMapper;
using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CartProfile : Profile
    {
        public CartProfile() 
        {
            CreateMap<CartDto, Brand>().ReverseMap();
            CreateMap<DeleteCartRequest, Brand>();
        }
    }
}
