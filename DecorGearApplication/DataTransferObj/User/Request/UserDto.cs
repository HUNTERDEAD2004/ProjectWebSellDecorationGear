﻿using DecorGearDomain.Enum;

namespace Application.DataTransferObj.User.Request
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public UserStatus Status { get; set; } = UserStatus.Active;
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        // public string? Token { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
