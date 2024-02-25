using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Migrations
{
    /// <inheritdoc />
    public partial class ChangingAppDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TariffTickets",
                table: "TariffTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TariffPermits",
                table: "TariffPermits");

            migrationBuilder.RenameTable(
                name: "TariffTickets",
                newName: "TicketsTariff");

            migrationBuilder.RenameTable(
                name: "TariffPermits",
                newName: "PermitsTariff");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsTariff",
                table: "TicketsTariff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermitsTariff",
                table: "PermitsTariff",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsTariff",
                table: "TicketsTariff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermitsTariff",
                table: "PermitsTariff");

            migrationBuilder.RenameTable(
                name: "TicketsTariff",
                newName: "TariffTickets");

            migrationBuilder.RenameTable(
                name: "PermitsTariff",
                newName: "TariffPermits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TariffTickets",
                table: "TariffTickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TariffPermits",
                table: "TariffPermits",
                column: "Id");
        }
    }
}
