using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Migrations
{
    /// <inheritdoc />
    public partial class AddDateTimeToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datetime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datetime",
                table: "Transactions");
        }
    }
}
