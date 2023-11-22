﻿namespace Mango.Services.CouponAPI.Model.DTO
{
    public class CouponDTO
    {
        public Guid? couponId { get; set; }
        public string couponCode { get; set; } = string.Empty;
        public double discountAmount { get; set; }
        public int minAmount { get; set; }

    }
}
