using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;

namespace DecorGearDomain.Data.Entities
{
    public class Order : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public int UserID { get; set; }

        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public int? VoucherID { get; set; } // 1 oder có tối đa 1 voucher ( có thể có hoặc không nên đẻ ? )

        [Required(ErrorMessage = "Không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int totalQuantity { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tổng giá phải là giá trị dương")]
        public double totalPrice { get; set; }

        [Range(1, 5, ErrorMessage = "Vui lòng lựa chọn từ 1 - 5 <(Hoàn thành:1) (Hoãn:2) (Hủy:3) (Đang vận chuyển:4) (Đã giao hàng:5)> ")]
        public OrderStatus Status { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự")]
        public string paymentMethod { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public DateTime OrderDate { get; set; } // ngày giao hàng


        // Khóa ngoại

        // 1 - n
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        // n - 1
        public virtual Voucher Voucher { get; set; }

        public virtual User User { get; set; }
    }
}
