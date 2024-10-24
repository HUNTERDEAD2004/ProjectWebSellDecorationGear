using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class KeyBoardDetailsProfile : Profile
    {
        public KeyBoardDetailsProfile()
        {
            CreateMap<KeyBoardDetailsDto, KeyboardDetail>().ReverseMap();
            CreateMap<CreateKeyBoardsRequest, KeyboardDetail>();
        }
    }
}
