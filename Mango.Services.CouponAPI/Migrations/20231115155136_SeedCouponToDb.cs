using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "coupon_id", "coupon_code", "discount_amount", "min_amount" },
                values: new object[,]
                {
                    { new Guid("87def2c8-b32a-4352-83ed-9339c6ef227a"), "40FF", 40.0, 80 },
                    { new Guid("d3986cd8-9e26-4603-ac49-3501be21adc6"), "20FF", 20.0, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "coupon_id",
                keyValue: new Guid("87def2c8-b32a-4352-83ed-9339c6ef227a"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "coupon_id",
                keyValue: new Guid("d3986cd8-9e26-4603-ac49-3501be21adc6"));
        }
    }
}
