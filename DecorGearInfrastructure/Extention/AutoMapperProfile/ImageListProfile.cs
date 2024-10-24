using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearDomain.Data.Entities;


namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class ImageListProfile : Profile
    {
        public ImageListProfile()
        {
            CreateMap<ImageListDto, ImageList>().ReverseMap();
            CreateMap<CreateImageRequest, ImageList>();
        }
    }
}
