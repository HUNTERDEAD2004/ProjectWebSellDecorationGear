using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
