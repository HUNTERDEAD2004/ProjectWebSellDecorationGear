using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class UpdateSubCategoryRequest
    {
        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }
    }
}
