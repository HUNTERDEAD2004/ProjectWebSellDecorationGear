using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace DecorGearDomain.Data.Entities
{
    public class ImageList : EntityBase
    {
        public int ImageListID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public List<string> ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string Description { get; set; }
        //Khóa ngoại
        public virtual Product Product { get; set; }
    }
}
