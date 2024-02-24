using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTicketTarrif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstHour15min",
                table: "TariffTickets",
                newName: "Each15minOnFirstHour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Each15minOnFirstHour",
                table: "TariffTickets",
                newName: "FirstHour15min");
        }
    }
}
