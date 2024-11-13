

using AutoMapper;
using DecorGearApplication.DataTransferObj.Address;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class AddressProflie : Profile
    {
        public AddressProflie()
        {
            CreateMap<AddressDto, Address>();
        }
       
    }
}
