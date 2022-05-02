using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EjendomsAnsvarlig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViceværtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjendomsAnsvarlig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejendom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VejNavn = table.Column<int>(type: "int", nullable: false),
                    BygningsNummer = table.Column<int>(type: "int", nullable: false),
                    PostNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandKode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejendom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejendom_EjendomsAnsvarlig_Id",
                        column: x => x.Id,
                        principalTable: "EjendomsAnsvarlig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vicevært",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vicevært", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vicevært_EjendomsAnsvarlig_Id",
                        column: x => x.Id,
                        principalTable: "EjendomsAnsvarlig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lejemål",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VejNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BygningsNummer = table.Column<int>(type: "int", nullable: false),
                    AndenAdresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandKode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookable = table.Column<bool>(type: "bit", nullable: false),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejemål", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejemål_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjendomVicevært",
                columns: table => new
                {
                    EjemdomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViceværtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Lejer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MellemNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    IndDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UdDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejer_Lejemål_Id",
                        column: x => x.Id,
                        principalTable: "Lejemål",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejerLejemålId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LejemålId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViceværtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Lejemål_LejemålId",
                        column: x => x.LejemålId,
                        principalTable: "Lejemål",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Lejer_LejerLejemålId",
                        column: x => x.LejerLejemålId,
                        principalTable: "Lejer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Booking_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rekvisition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntalTimer = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViceværtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LejerLejemålId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekvisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Lejer_LejerLejemålId",
                        column: x => x.LejerLejemålId,
                        principalTable: "Lejer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_LejemålId",
                table: "Booking",
                column: "LejemålId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_LejerLejemålId",
                table: "Booking",
                column: "LejerLejemålId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ViceværtId",
                table: "Booking",
                column: "ViceværtId");

            migrationBuilder.CreateIndex(
                name: "IX_EjendomVicevært_ViceværtId",
                table: "EjendomVicevært",
                column: "ViceværtId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejemål_EjendomId",
                table: "Lejemål",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_EjendomId",
                table: "Rekvisition",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_LejerLejemålId",
                table: "Rekvisition",
                column: "LejerLejemålId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_ViceværtId",
                table: "Rekvisition",
                column: "ViceværtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "EjendomVicevært");

            migrationBuilder.DropTable(
                name: "Rekvisition");

            migrationBuilder.DropTable(
                name: "Lejer");

            migrationBuilder.DropTable(
                name: "Vicevært");

            migrationBuilder.DropTable(
                name: "Lejemål");

            migrationBuilder.DropTable(
                name: "Ejendom");

            migrationBuilder.DropTable(
                name: "EjendomsAnsvarlig");
        }
    }
}
