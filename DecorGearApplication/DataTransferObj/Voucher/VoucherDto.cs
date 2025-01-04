using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class VoucherDto
    {
        public int VoucherID { get; set; }
        public string VoucherName { get; set; }
        public double VoucherPercent { get; set; }
        public DateTime expiry { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public EntityStatus Status { get; set; }
    }
}
