using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.Brand
{
    public class BrandDto
    {
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public EntityStatus Status { get; set; } 
    }
}
