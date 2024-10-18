using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Enum
{
    public enum ErrorMessage
    {
        Successful = 1,
        Failed = 2,
        Null = 3,
        RoleNotFound = 4,
        DatabaseError = 5,
        InvalidArgument = 6,
        UnknownError = 7,
        UsernameExists = 8,
        EmailExists = 9,
        QuantityExceedsStock
    }
}
