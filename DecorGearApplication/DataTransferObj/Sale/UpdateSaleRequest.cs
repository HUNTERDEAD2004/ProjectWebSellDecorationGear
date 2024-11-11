namespace DecorGearApplication.DataTransferObj.Sale
{
    public class UpdateSaleRequest
    {
        public int SaleID { get; set; }

        public string SaleName { get; set; }

        public int SalePercent { get; set; }

        public int UserID { get; set; }
    }
}
