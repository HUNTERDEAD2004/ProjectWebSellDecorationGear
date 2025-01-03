using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Sale
{
    public class SaleDto
    {
        public int SaleID { get; set; }

        public string SaleName { get; set; }

        public int SalePercent { get; set; }

        public EntityStatus Status { get; set; }
    }
}
