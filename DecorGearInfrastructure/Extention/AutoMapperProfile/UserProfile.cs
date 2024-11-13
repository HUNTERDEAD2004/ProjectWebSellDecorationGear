using AutoMapper;
using DecorGearApplication.DataTransferObj.User.Request;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Ánh xạ từ UserCreateRequest sang User
            CreateMap<UserCreateRequest, User>().ReverseMap();
            CreateMap<User, UserDto>()
                 .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.CreatedTime.DateTime));//ReverseMap();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}
