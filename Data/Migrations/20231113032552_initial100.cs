using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_ShopConCung.Data.Migrations
{
    public partial class initial100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductPrice",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Products",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
