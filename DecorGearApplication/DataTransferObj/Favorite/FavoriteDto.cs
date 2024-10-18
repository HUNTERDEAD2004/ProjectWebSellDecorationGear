using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj
{
    public class FavoriteDto
    {
        public int FavoriteID { get; set; }


        public string UserID { get; set; }


        public string ProductID { get; set; }
    }
}
