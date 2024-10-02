using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class CreateFeedBackRequest
    {
        public Guid UserID { get; set; }

        public Guid ProductID { get; set; }

        public string Comment { get; set; }
    }
}
