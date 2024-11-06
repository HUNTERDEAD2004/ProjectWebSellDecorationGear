using AutoMapper;
using DecorGearApplication.DataTransferObj.Home;
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

            CreateMap<Product, TopViewedProductDto>()
           .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
           .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.SubCategoryName));

            CreateMap<Product, TopHotProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.SubCategoryName))
                .ForMember(dest => dest.TotalSold, opt => opt.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity)))
                .ForMember(dest => dest.FavoriteCount, opt => opt.MapFrom(src => src.Favorites.Count));
        }


    }
}
