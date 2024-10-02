using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Favorite
{
    public class CreateFavoriteRequest
    {
        public Guid UserID { get; set; }

        public Guid ProductID { get; set; }
    }
}
