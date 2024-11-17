namespace DecorGearApplication.DataTransferObj.KeyBoardDetails
{
    public class KeyBoardDetailsDto
    {
        public int KeyboardDetailID { get; set; }

        public int ProductID { get; set; }

        public string Color { get; set; }

        public string Layout { get; set; }

        public string Case { get; set; }

        public string Switch { get; set; }

        public int? SwitchLife { get; set; }

        public string? Led { get; set; }

        public string? KeycapMaterial { get; set; }

        public string? SwitchMaterial { get; set; }

        public string? SS { get; set; }

        public string? Stabilizes { get; set; }

        public string? PCB { get; set; }

        // Sửa thuộc tính ImageProduct thành List<string>

        public List<string> ImageProduct { get; set; }
    }
}
