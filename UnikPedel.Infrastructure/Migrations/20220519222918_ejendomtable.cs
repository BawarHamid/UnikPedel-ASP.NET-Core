using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikPedel.Infrastructure.Migrations
{
    public partial class ejendomtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropColumn(
        //        name: "Version",
        //        table: "Lejer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Lejer",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
