using AutoMapper;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<UpdateMemberRequest, Member>().ReverseMap();
            CreateMap<CreateMemberRequest, Member>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
            // Cấu hình AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MemberDto, Member>();
            });
            IMapper mapper = config.CreateMapper();
        }
    }
}
