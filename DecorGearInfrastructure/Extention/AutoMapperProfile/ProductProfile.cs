using AutoMapper;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearDomain.Data.Entities;


namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
