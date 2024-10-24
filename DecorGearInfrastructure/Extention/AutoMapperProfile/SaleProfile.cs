using AutoMapper;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleDto, Sale>().ReverseMap();
            CreateMap<CreateSaleRequest, Sale>();
            CreateMap<UpdateSaleRequest, Sale>();
            CreateMap<DeleteSaleRequest, Sale>();
            CreateMap<ViewSaleRequest, Sale>();
        }
    }
}
