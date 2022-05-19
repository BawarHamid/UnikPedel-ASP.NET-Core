using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class Lejemål : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "By",
                table: "Lejemål",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Lejemål",
                newName: "By");
        }
    }
}
