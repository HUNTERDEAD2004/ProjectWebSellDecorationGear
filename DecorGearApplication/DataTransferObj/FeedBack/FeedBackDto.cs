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
        public Guid FeedBackID { get; set; }

        public Guid UserID { get; set; }

        public Guid ProductID { get; set; }

        public string Comment { get; set; }
    }
}
