﻿namespace DecorGearApplication.DataTransferObj.User.Email
{
    public class VerifyCodeRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
