using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.Role;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
