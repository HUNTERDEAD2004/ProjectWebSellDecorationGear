using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class CreateImageRequest
    {
        public int ProductID { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
