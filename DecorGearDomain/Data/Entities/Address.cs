using System.ComponentModel.DataAnnotations.Schema;


namespace DecorGearDomain.Data.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }         
        public int UserId { get; set; }           
        public string ProvinceCode { get; set; }   
        public string ProvinceName { get; set; }     
        public string DistrictCode { get; set; }     
        public string DistrictName { get; set; }     
        public string WardCode { get; set; }         
        public string WardName { get; set; }

        public virtual User User { get; set; }
    }
}
