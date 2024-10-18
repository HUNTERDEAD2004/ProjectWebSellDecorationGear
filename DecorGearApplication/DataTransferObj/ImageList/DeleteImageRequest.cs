using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.ImageList
{
    public class DeleteImageRequest
    {
        public int ImageListID { get; set; }

        public string UserID { get; set; }
    }
}
