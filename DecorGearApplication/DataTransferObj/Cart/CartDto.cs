﻿namespace DecorGearApplication.DataTransferObj
{
    public class CartDto
    {
        public int CartID { get; set; }

        public int UserID { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
