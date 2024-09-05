using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Favorite
{
    public class DeleteFavoriteRequest
    {
        public int FavoriteID { get; set; }


        public string UserID { get; set; }
    }
}
