using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class CreateImageRequest
    {
        public string ProductID { get; set; }

        public List<string> ImagePath { get; set; }

        public string Description { get; set; }

        public string UserID { get; set; }
    }
}
