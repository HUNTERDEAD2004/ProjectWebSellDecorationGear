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
        public Guid SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public Guid CategoryID { get; set; }
    }
}
