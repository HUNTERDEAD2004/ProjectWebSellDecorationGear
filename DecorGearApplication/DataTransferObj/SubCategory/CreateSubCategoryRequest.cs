﻿using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class CreateSubCategoryRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(255, ErrorMessage = "Không được vượt quá 255 ký tự")]
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
