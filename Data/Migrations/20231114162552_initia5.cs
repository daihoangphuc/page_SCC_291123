using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLy_ShopConCung.Data.Migrations
{
    public partial class initia5 : Migration		
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
	name: "User",
	columns: table => new
	{
		UserId = table.Column<int>(type: "int", nullable: false)
			.Annotation("SqlServer:Identity", "1, 1"),
		Password = table.Column<string>(type: "nvarchar(300)", maxLength: 30, nullable: false),

		UserName = table.Column<string>(type: "nvarchar(300)", maxLength: 30, nullable: false),
		Email = table.Column<string>(type: "nvarchar(300)", maxLength: 30, nullable: true),
		Role = table.Column<string>(type: "nvarchar(30)", nullable: true),
	},
	constraints: table =>
	{
		table.PrimaryKey("PK_Brands", x => x.UserId);
	});

		}
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "User");


		}
	}
}
