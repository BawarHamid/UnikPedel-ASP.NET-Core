using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class EjendomsAnsvarligid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjendomsAnsvarlig",
                table: "EjendomsAnsvarlig");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EjendomsAnsvarlig",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjendomsAnsvarlig",
                table: "EjendomsAnsvarlig",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EjendomsAnsvarlig_ViceværtId",
                table: "EjendomsAnsvarlig",
                column: "ViceværtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjendomsAnsvarlig",
                table: "EjendomsAnsvarlig");

            migrationBuilder.DropIndex(
                name: "IX_EjendomsAnsvarlig_ViceværtId",
                table: "EjendomsAnsvarlig");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EjendomsAnsvarlig");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjendomsAnsvarlig",
                table: "EjendomsAnsvarlig",
                columns: new[] { "ViceværtId", "EjendomId" });
        }
    }
}
