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
                name: "Ejendom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
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
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    efterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vicevært", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Afdeling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EjendomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afdeling_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AfdelingAnsvarlig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViceværtId = table.Column<int>(type: "int", nullable: false),
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfdelingAnsvarlig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AfdelingAnsvarlig_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdeling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AfdelingAnsvarlig_Vicevært_ViceværtId",
                        column: x => x.ViceværtId,
                        principalTable: "Vicevært",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beboer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfterNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    AfdelingId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beboer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beboer_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdeling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lejlighed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejlighed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejlighed_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdeling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rekvisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntalTimer = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViceværtId = table.Column<int>(type: "int", nullable: false),
                    BeboerId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekvisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Beboer_BeboerId",
                        column: x => x.BeboerId,
                        principalTable: "Beboer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rekvisition_Vicevært_ViceværtId",
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
                    BeboerId = table.Column<int>(type: "int", nullable: false),
                    GæsteLejlighedId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Beboer_BeboerId",
                        column: x => x.BeboerId,
                        principalTable: "Beboer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Lejlighed_GæsteLejlighedId",
                        column: x => x.GæsteLejlighedId,
                        principalTable: "Lejlighed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afdeling_EjendomId",
                table: "Afdeling",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_AfdelingAnsvarlig_AfdelingId",
                table: "AfdelingAnsvarlig",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_AfdelingAnsvarlig_ViceværtId",
                table: "AfdelingAnsvarlig",
                column: "ViceværtId");

            migrationBuilder.CreateIndex(
                name: "IX_Beboer_AfdelingId",
                table: "Beboer",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BeboerId",
                table: "Booking",
                column: "BeboerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GæsteLejlighedId",
                table: "Booking",
                column: "GæsteLejlighedId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejlighed_AfdelingId",
                table: "Lejlighed",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_BeboerId",
                table: "Rekvisition",
                column: "BeboerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekvisition_ViceværtId",
                table: "Rekvisition",
                column: "ViceværtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfdelingAnsvarlig");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Rekvisition");

            migrationBuilder.DropTable(
                name: "Lejlighed");

            migrationBuilder.DropTable(
                name: "Beboer");

            migrationBuilder.DropTable(
                name: "Vicevært");

            migrationBuilder.DropTable(
                name: "Afdeling");

            migrationBuilder.DropTable(
                name: "Ejendom");
        }
    }
}
