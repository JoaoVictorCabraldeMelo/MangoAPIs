using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.CouponAPI.Model
{
    public class Coupon
    {
        [Key]
        [Column("coupon_id")]
        public Guid couponId { get; set; }

        [Required]
        [Column("coupon_code")]
        [StringLength(125, ErrorMessage = "Coupon Code cannot have more than 125 characters")]
        public string couponCode { get; set; } = string.Empty;

        [Required]
        [Column("discount_amount")]
        public double discountAmount { get; set; }

        [Column("min_amount")]
        public int minAmount { get; set; }

    }
}
