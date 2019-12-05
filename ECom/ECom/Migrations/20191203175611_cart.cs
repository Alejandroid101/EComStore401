using Microsoft.EntityFrameworkCore.Migrations;

namespace ECom.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "CartID",
                table: "Cart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationID",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
