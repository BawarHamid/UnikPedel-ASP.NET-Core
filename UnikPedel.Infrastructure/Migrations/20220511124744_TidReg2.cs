using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class TidReg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejer_Lejemål_Id",
                table: "Lejer");

            migrationBuilder.DropColumn(
                name: "AntalTimer",
                table: "Rekvisition");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "Rekvisition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LejemålId1",
                table: "Lejer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "VejNavn",
                table: "Ejendom",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LandKode",
                table: "Ejendom",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TidRegistrering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AntalTimer = table.Column<double>(type: "float", nullable: false),
                    ViceværtId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RekvisitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TidRegistrering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TidRegistrering_Rekvisition_RekvisitionId",
                        column: x => x.RekvisitionId,
                        principalTable: "Rekvisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TidRegistrering_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemålId1",
                table: "Lejer",
                column: "LejemålId1");

            migrationBuilder.CreateIndex(
                name: "IX_TidRegistrering_RekvisitionId",
                table: "TidRegistrering",
                column: "RekvisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TidRegistrering_ViceværtId",
                table: "TidRegistrering",
                column: "ViceværtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejer_Lejemål_LejemålId1",
                table: "Lejer",
                column: "LejemålId1",
                principalTable: "Lejemål",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejer_Lejemål_LejemålId1",
                table: "Lejer");

            migrationBuilder.DropTable(
                name: "TidRegistrering");

            migrationBuilder.DropIndex(
                name: "IX_Lejer_LejemålId1",
                table: "Lejer");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "Rekvisition");

            migrationBuilder.DropColumn(
                name: "LejemålId1",
                table: "Lejer");

            migrationBuilder.AddColumn<double>(
                name: "AntalTimer",
                table: "Rekvisition",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "VejNavn",
                table: "Ejendom",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LandKode",
                table: "Ejendom",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejer_Lejemål_Id",
                table: "Lejer",
                column: "Id",
                principalTable: "Lejemål",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
