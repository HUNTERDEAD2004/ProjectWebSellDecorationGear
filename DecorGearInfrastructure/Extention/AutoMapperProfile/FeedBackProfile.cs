using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecorGearInfrastructure.Database.Configuration;
using DecorGearApplication.DataTransferObj.FeedBack;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class FeedBackProfile : Profile
    {
        public FeedBackProfile() 
        {
            CreateMap<FeedBackDto, FeedBack>().ReverseMap();
            CreateMap<CreateFeedBackRequest, FeedBack>();
        }
    }
}
