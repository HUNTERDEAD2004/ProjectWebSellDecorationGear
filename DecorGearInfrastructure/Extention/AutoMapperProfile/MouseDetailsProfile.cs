using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class MouseDetailsProfile : Profile
    {
        public MouseDetailsProfile()
        {
            CreateMap<MouseDetailsDto, MouseDetail>().ReverseMap();
            CreateMap<CreateMouseRequest, MouseDetail>();
            CreateMap<UpdateMouseRequest, MouseDetail>();
            CreateMap<DeleteMouseRequest, KeyboardDetail>();
            CreateMap<ViewKeyBoardsRequest, MouseDetail>();
        }
    }
}
