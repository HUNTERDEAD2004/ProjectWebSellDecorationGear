using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OderDto, Order>().ReverseMap();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<DeleteOrderRequest, Order>();
            CreateMap<ViewOrderRequest, Order>();
        }
    }
}
