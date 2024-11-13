using AutoMapper;
using DecorGearApplication.DataTransferObj.Address;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;


namespace DecorGearInfrastructure.Implement
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Address> GetAddressByUserIdAsync(int userId)
        {
            return await _context.Address.FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task<Address> SaveAddressAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            await _context.AddAsync(address);
            await _context.SaveChangesAsync();

            return address;
        }

    }
}
