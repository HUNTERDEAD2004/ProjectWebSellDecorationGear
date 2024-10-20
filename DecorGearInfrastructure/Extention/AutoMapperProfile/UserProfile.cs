﻿using Application.DataTransferObj.User.Request;
using AutoMapper;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearDomain.Data.Entities;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
