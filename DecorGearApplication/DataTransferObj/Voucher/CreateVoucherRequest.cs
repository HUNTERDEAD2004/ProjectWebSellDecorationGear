namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class CreateVoucherRequest
    {
        public string VoucherName { get; set; }

        public int VoucherPercent { get; set; }

        public string UserID { get; set; }
        public DateTime expiry { get; set; }
    }
}
