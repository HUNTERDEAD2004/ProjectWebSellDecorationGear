using AutoMapper;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class FeedBackProfile : Profile
    {
        public FeedBackProfile()
        {
            CreateMap<FeedBackDto, FeedBack>().ReverseMap();
            CreateMap<CreateFeedBackRequest, FeedBack>();
            CreateMap<UpdateFeedBackRequest, FeedBack>();
        }
    }
}
