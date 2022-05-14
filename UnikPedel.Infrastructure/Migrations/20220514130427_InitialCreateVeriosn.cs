using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class InitialCreateVeriosn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ejendom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VejNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BygningsNummer = table.Column<int>(type: "int", nullable: false),
                    PostNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandKode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejendom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vicevært",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vicevært", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EjendomsAnsvarlig",
                columns: table => new
                {
                    ViceværtId = table.Column<int>(type: "int", nullable: false),
                    EjendomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjendomsAnsvarlig", x => new { x.ViceværtId, x.EjendomId });
                    table.ForeignKey(
                        name: "FK_EjendomsAnsvarlig_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EjendomsAnsvarlig_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EjendomVicevært",
                columns: table => new
                {
                    EjemdomId = table.Column<int>(type: "int", nullable: false),
                    ViceværtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjendomVicevært", x => new { x.EjemdomId, x.ViceværtId });
                    table.ForeignKey(
                        name: "FK_EjendomVicevært_Ejendom_EjemdomId",
                        column: x => x.EjemdomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjendomVicevært_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejerId = table.Column<int>(type: "int", nullable: false),
                    LejemålId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lejemål",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VejNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BygningsNummer = table.Column<int>(type: "int", nullable: false),
                    AndenAdresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandKode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookable = table.Column<bool>(type: "bit", nullable: false),
                    EjendomId = table.Column<int>(type: "int", nullable: false),
                    RekvisitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejemål", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejemål_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lejer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MellemNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    IndDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UdDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LejemålId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejer_Lejemål_LejemålId",
                        column: x => x.LejemålId,
                        principalTable: "Lejemål",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rekvisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViceværtId = table.Column<int>(type: "int", nullable: false),
                    LejerId = table.Column<int>(type: "int", nullable: false),
                    EjendomId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekvisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rekvisition_Lejer_LejerId",
                        column: x => x.LejerId,
                        principalTable: "Lejer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rekvisition_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TidRegistrering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AntalTimer = table.Column<double>(type: "float", nullable: false),
                    ViceværtId = table.Column<int>(type: "int", nullable: true),
                    RekvisitionId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Booking_LejemålId",
                table: "Booking",
                column: "LejemålId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_LejerId",
                table: "Booking",
                column: "LejerId");

            migrationBuilder.CreateIndex(
                name: "IX_EjendomsAnsvarlig_EjendomId",
                table: "EjendomsAnsvarlig",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_EjendomVicevært_ViceværtId",
                table: "EjendomVicevært",
                column: "ViceværtId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejemål_EjendomId",
                table: "Lejemål",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejemål_RekvisitionId",
                table: "Lejemål",
                column: "RekvisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemålId",
                table: "Lejer",
                column: "LejemålId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_EjendomId",
                table: "Rekvisition",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_LejerId",
                table: "Rekvisition",
                column: "LejerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_ViceværtId",
                table: "Rekvisition",
                column: "ViceværtId");

            migrationBuilder.CreateIndex(
                name: "IX_TidRegistrering_RekvisitionId",
                table: "TidRegistrering",
                column: "RekvisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TidRegistrering_ViceværtId",
                table: "TidRegistrering",
                column: "ViceværtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Lejemål_LejemålId",
                table: "Booking",
                column: "LejemålId",
                principalTable: "Lejemål",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Lejer_LejerId",
                table: "Booking",
                column: "LejerId",
                principalTable: "Lejer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejemål_Rekvisition_RekvisitionId",
                table: "Lejemål",
                column: "RekvisitionId",
                principalTable: "Rekvisition",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejer_Lejemål_LejemålId",
                table: "Lejer");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "EjendomsAnsvarlig");

            migrationBuilder.DropTable(
                name: "EjendomVicevært");

            migrationBuilder.DropTable(
                name: "TidRegistrering");

            migrationBuilder.DropTable(
                name: "Lejemål");

            migrationBuilder.DropTable(
                name: "Rekvisition");

            migrationBuilder.DropTable(
                name: "Ejendom");

            migrationBuilder.DropTable(
                name: "Lejer");

            migrationBuilder.DropTable(
                name: "Vicevært");
        }
    }
}
