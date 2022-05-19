using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class lejemååål : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejemål_Rekvisition_RekvisitionId",
                table: "Lejemål");

            migrationBuilder.DropIndex(
                name: "IX_Lejemål_RekvisitionId",
                table: "Lejemål");

            migrationBuilder.DropColumn(
                name: "RekvisitionId",
                table: "Lejemål");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RekvisitionId",
                table: "Lejemål",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lejemål_RekvisitionId",
                table: "Lejemål",
                column: "RekvisitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejemål_Rekvisition_RekvisitionId",
                table: "Lejemål",
                column: "RekvisitionId",
                principalTable: "Rekvisition",
                principalColumn: "Id");
        }
    }
}
