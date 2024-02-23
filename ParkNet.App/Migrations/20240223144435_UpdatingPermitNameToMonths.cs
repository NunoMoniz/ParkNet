using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingPermitNameToMonths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Permits",
                newName: "Months");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Months",
                table: "Permits",
                newName: "Name");
        }
    }
}
