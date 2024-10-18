using AutoMapper;
using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
