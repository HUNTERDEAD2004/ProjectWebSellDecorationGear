using AutoMapper;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class MouseDetailsProfile : Profile
    {
        public MouseDetailsProfile()
        {
            CreateMap<MouseDetailsDto, MouseDetail>().ReverseMap();
            CreateMap<CreateMouseRequest, MouseDetail>();
        }
    }
}
