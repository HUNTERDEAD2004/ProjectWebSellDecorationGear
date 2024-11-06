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
            CreateMap<CartDto, Brand>().ReverseMap();
            CreateMap<CartDto, Cart>().ReverseMap();

            CreateMap<DeleteCartRequest, Brand>();
        }
    }
}
