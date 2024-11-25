namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class ViewKeyBoardsDetailRequest
    {
        public int? ProductID { get; set; }

        public int? KeyboardDetailID { get; set; }

        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public int? View { get; set; }

        public int? Quantity { get; set; }

        public double? Weight { get; set; }

        public string? Description { get; set; }

        public string? Size { get; set; }

        public int? BatteryCapacity { get; set; } // dung lượng pin

        public string? Color { get; set; }

        public string? Layout { get; set; }

        public string? Case { get; set; }

        public string? Switch { get; set; }

        public int? SwitchLife { get; set; }

        public string? Led { get; set; }

        public string? KeycapMaterial { get; set; }

        public string? SwitchMaterial { get; set; }

        public string? SS { get; set; }

        public string? Stabilizes { get; set; }

        public string? PCB { get; set; }
    }
}
