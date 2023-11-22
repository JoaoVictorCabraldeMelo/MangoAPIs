using Mango.Services.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>()
                .Property(b => b.couponId)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                couponId = Guid.NewGuid(),
                couponCode = "20FF",
                discountAmount = 20,
                minAmount = 40,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                couponId = Guid.NewGuid(),
                couponCode = "40FF",
                discountAmount = 40,
                minAmount = 80,
            });
        }
    }
}
