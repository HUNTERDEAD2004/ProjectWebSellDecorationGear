using AutoMapper;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<CreateBrandRequest, Brand>();
        }
    }
}
