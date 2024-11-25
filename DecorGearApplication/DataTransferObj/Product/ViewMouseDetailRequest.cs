namespace DecorGearApplication.DataTransferObj.MouseDetails
{
    public class ViewMouseDetailRequest
    {
        public int? ProductID { get; set; }

        public int? MouseDetailID { get; set; }

        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public int? View { get; set; }

        public int? Quantity { get; set; }

        public double? Weight { get; set; }

        public string? Description { get; set; }

        public string? Size { get; set; }

        public int? BatteryCapacity { get; set; } // dung lượng pin

        public string? Color { get; set; }

        public int? DPI { get; set; }

        public string? Connectivity { get; set; }

        public string? Dimensions { get; set; }

        public string? Material { get; set; }

        public string? EyeReading { get; set; }

        public int? Button { get; set; }

        public string? LED { get; set; }

        public string? SS { get; set; }
    }
}
