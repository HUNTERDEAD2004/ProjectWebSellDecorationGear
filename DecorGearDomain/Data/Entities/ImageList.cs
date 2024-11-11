using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorGearDomain.Data.Entities
{
    public class ImageList : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageListID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Không được vượt quá 500 ký tự")]
        public string? Description { get; set; }

        //Khóa ngoại
        public virtual Product Product { get; set; }
    }
}
