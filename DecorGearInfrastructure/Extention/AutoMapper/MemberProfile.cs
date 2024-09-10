using AutoMapper;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapper
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<CreateUpdateMemberRequest, Member>().ReverseMap();
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
