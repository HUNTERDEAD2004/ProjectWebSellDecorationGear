﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DataTransferObj.User.Ultilities
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            if (!String.IsNullOrWhiteSpace(UserName) || !String.IsNullOrWhiteSpace(Password))
            {
                return true;
            }
            return false;
        }
    }
}
