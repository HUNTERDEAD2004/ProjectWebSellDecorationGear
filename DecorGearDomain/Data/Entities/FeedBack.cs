using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorGearDomain.Data.Entities
{
    public class FeedBack : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedBackID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public string Comment { get; set; }


        //Khóa ngoại
        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
