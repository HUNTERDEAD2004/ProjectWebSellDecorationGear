using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Brand
{
    public class CreateUpdateBrandRequest
    {
        public string BrandID { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public string UserID { get; set; }
    }
}
