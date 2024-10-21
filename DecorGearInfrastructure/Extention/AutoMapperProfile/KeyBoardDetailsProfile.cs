using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class KeyBoardDetailsProfile : Profile
    {
        public KeyBoardDetailsProfile()
        {
            CreateMap<KeyBoardDetailsDto, KeyboardDetail>().ReverseMap();
            CreateMap<CreateKeyBoardsRequest, KeyboardDetail>();
            CreateMap<UpdateKeyBoardsRequest, KeyboardDetail>();
            CreateMap<DeleteKeyBoardsRequest, KeyboardDetail>();
            CreateMap<ViewKeyBoardsRequest, KeyboardDetail>();
        }
    }
}
