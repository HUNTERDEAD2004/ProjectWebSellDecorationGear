using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorGearDomain.Data.Entities
{
    public class CartDetail : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailID { get; set; }

        public int ProductID { get; set; }

        public int CartID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public EntityStatus Status { get; set; }

        // Khóa ngoại

        // n - 1

        public virtual Product Product { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
