using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class CouponToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    couponid = table.Column<Guid>(name: "coupon_id", type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    couponcode = table.Column<string>(name: "coupon_code", type: "nvarchar(125)", maxLength: 125, nullable: false),
                    discountamount = table.Column<double>(name: "discount_amount", type: "float", nullable: false),
                    minamount = table.Column<int>(name: "min_amount", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.couponid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
