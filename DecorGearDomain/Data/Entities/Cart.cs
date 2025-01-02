using DecorGearDomain.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorGearDomain.Data.Entities
{
    public class Cart : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartID { get; set; }

        public int UserID { get; set; }

        public int TotalQuantity { get; set; }

        public double TotalAmount { get; set; }

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // 1 - 1
        public virtual User User { get; set; }
    }
}
