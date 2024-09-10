using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class UpdateSubCategoryRequest
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public string UserID { get; set; }
    }
}
