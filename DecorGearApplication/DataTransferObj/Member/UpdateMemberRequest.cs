﻿using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.Member
{
    public class UpdateMemberRequest
    {
        public int MemberID { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số dương")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Không được để trống.")]
        public DateTime ExpiryDate { get; set; }

        [Range(1, 8, ErrorMessage = "Hãy thiết lập trạng thái")]
        public EntityStatus Status { get; set; }
    }
}
