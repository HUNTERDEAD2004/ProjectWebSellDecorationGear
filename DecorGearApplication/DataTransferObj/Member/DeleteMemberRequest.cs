﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Member
{
    public class DeleteMemberRequest
    {
        public int MemberID { get; set; }

        public string UserID { get; set; }
    }
}
