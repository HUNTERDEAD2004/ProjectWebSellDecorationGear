using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DataTransferObj.User.Ultilities
{
    public class ConfirmCodeRequest
    {
        public Guid ID { get; set; }
        public string? Code { get; set; }
    }
}
