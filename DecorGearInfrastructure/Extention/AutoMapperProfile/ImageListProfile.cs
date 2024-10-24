using AutoMapper;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
