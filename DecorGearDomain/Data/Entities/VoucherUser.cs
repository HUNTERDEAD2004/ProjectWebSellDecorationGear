using System.ComponentModel.DataAnnotations.Schema;

namespace DecorGearDomain.Data.Entities
{
    public class VoucherUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoucherUserId { get; set; }

        public int UserID { get; set; }

        public int VoucherID { get; set; }

        public int Status { get; set; }

        public virtual User User { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
