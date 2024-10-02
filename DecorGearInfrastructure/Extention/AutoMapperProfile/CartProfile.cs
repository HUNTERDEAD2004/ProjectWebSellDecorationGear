using AutoMapper;
using DecorGearApplication.DataTransferObj;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CartProfile : Profile
    {
        public CartProfile() 
        {
            CreateMap<CartDto, Brand>().ReverseMap();
        }
    }
}
