using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
