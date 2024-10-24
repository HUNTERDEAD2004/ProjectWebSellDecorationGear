namespace DecorGearApplication.DataTransferObj.Voucher
{
    public class UpdateVoucherRequest
    {
        public int VoucherID { get; set; }

        public string VoucherName { get; set; }

        public int VoucherPercent { get; set; }

        public int UserID { get; set; }
    }
}
