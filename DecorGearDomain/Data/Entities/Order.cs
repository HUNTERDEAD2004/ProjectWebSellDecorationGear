using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;

namespace DecorGearDomain.Data.Entities
{
    public class Order : EntityBase
    {
        public int OderID { get; set; }

        [Required]
        public string UserID { get; set; }
        
        public int? VoucherID { get; set; } // 1 oder có tối đa 1 voucher ( có thể có hoặc không nên đẻ ? )

        public int totalQuantity { get; set; }

        public decimal totalPrice { get; set; } 

        public OrderStatus Status { get; set; } 

        public string paymentMethod { get; set; }

        public float size { get; set; }

        public float weight { get; set; }

        public DateTime OrderDate { get; set; } // ngày đặt hàng

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // n - 1
        public virtual Voucher Voucher { get; set; }

        public virtual User User { get; set; }
    }
}
