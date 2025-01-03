using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;

namespace DecorGearApplication.DataTransferObj.SubCategory
{
    public class SubCategoryDto
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryID { get; set; }

        public EntityStatus Status { get; set; }
    }
}
