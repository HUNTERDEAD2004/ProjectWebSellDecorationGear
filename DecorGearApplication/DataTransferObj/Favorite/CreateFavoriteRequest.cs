using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Favorite
{
    public class CreateFavoriteRequest
    {
        public int UserID { get; set; }

        public int ProductID { get; set; }
    }
}
