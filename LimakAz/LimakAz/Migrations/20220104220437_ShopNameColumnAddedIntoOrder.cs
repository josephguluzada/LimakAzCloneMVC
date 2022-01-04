using Microsoft.EntityFrameworkCore.Migrations;

namespace LimakAz.Migrations
{
    public partial class ShopNameColumnAddedIntoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "Orders");
        }
    }
}
