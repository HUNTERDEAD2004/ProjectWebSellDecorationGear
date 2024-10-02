using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class CreateSubCategoryRequest
    {
        public string SubCategoryName { get; set; }

        public Guid CategoryID { get; set; }
    }
}
