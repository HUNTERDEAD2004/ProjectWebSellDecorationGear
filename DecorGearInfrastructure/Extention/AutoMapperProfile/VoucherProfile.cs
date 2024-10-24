using AutoMapper;
using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearDomain.Data.Entities;


namespace DecorGearInfrastructure.Extention.AutoMapperProfile
{
    public class VoucherProfile : Profile
    {
        public VoucherProfile()
        {
            CreateMap<VoucherDto, Voucher>().ReverseMap();
            CreateMap<CreateVoucherRequest, Voucher>();
            CreateMap<UpdateVoucherRequest, Voucher>();
            CreateMap<DeleteVoucherRequest, Voucher>();
            CreateMap<ViewVoucherRequest, Voucher>();
        }
    }
}
