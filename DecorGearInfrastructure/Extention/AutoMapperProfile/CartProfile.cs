using AutoMapper;
using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>().ReverseMap();
        }
    }
}
