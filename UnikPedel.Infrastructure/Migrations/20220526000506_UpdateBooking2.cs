using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class UpdateBooking2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Lejemål_LejemålId",
                table: "Booking");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Lejemål_LejemålId",
                table: "Booking",
                column: "LejemålId",
                principalTable: "Lejemål",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Lejemål_LejemålId",
                table: "Booking");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Lejemål_LejemålId",
                table: "Booking",
                column: "LejemålId",
                principalTable: "Lejemål",
                principalColumn: "Id");
        }
    }
}
