using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.FeedBack
{
    public class FeedBackDto
    {
        public int FeedBackID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public string Comment { get; set; }
    }
}
