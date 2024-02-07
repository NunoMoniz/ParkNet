using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entry",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Exit",
                table: "Tickets");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDateTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDateTime",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ExitDateTime",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Entry",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Exit",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
