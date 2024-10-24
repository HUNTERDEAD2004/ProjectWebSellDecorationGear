using AutoMapper;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class CartDetailProfile : Profile
    {
        public CartDetailProfile()
        {
            CreateMap<CartDetailDto, CartDetail>().ReverseMap();
            CreateMap<CreateCartDetailRequest, CartDetail>();
            CreateMap<UpdateCartDetailRequest, CartDetail>();
            CreateMap<ViewCartRequest, CartDetail>();
        }
    }
}
