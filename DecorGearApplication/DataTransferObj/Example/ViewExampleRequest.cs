using DecorGearApplication.ValueObj.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.DataTransferObj.Example
{
    public class ViewExampleRequest  : PaginationRequest
    {
        // tim kiem theo ten
        public string Name {  get; set; }   
    }
}
