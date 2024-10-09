using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class SubCategoryDto
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }
    }
}
