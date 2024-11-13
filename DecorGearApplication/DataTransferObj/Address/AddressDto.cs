

namespace DecorGearApplication.DataTransferObj.Address
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string WardCode { get; set; }
        public string WardName { get; set; }
    }
}
