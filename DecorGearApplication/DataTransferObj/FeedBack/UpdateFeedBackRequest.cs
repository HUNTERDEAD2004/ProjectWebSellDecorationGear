using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class UpdateFeedBackRequest
    {
        public int FeedBackID { get; set; }

        public string Comment { get; set; }

        public string UserID { get; set; }
    }
}
