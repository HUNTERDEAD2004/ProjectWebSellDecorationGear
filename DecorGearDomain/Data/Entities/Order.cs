using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;

namespace DecorGearDomain.Data.Entities
{
    public class Order : EntityBase
    {
        [Required(ErrorMessage = "Không được để trống")]
        public int OderID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string UserID { get; set; }
        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public int? VoucherID { get; set; } // 1 oder có tối đa 1 voucher ( có thể có hoặc không nên đẻ ? )

        [Required(ErrorMessage = "Không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int totalQuantity { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tổng giá phải là giá trị dương")]
        public decimal totalPrice { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public OrderStatus Status { get; set; }


        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public string paymentMethod { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0.0, float.MaxValue, ErrorMessage = "Phải là giá trị dương")]
        public float size { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0.0, float.MaxValue, ErrorMessage = "Phải là giá trị dương")]
        public float weight { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime OrderDate { get; set; } // ngày đặt hàng

        // Khóa ngoại

        // 1 - n
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        // n - 1
        public virtual Voucher Voucher { get; set; }

        public virtual User User { get; set; }
    }
}
