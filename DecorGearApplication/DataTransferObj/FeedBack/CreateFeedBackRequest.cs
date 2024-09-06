using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class CreateFeedBackRequest
    {
        public string UserID { get; set; }

        public string ProductID { get; set; }

        public string Comment { get; set; }
    }
}
