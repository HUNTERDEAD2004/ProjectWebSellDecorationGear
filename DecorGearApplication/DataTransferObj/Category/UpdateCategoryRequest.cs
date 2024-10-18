using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Category
{
    public class UpdateCategoryRequest
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string UserID { get; set; }
    }
}
