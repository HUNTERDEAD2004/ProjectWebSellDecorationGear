using DecorGearApplication.DataTransferObj.Address;
using DecorGearDomain.Data.Entities;

namespace DecorGearApplication.Interface
{
    public interface IAddressRepository
    {
         Task<Address> SaveAddressAsync(AddressDto address);

        Task<Address> GetAddressByUserIdAsync(int userId);
    }
}
