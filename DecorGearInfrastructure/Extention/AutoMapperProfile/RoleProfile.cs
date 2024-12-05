using AutoMapper;
using DecorGearApplication.DataTransferObj.Role;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
            CreateMap<DeleteRoleRequest, Role>();
            CreateMap<ViewRoleRequest, Role>();
        }
    }
}
