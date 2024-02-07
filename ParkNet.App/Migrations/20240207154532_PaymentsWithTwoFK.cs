using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsWithTwoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpaceId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpaceId",
                table: "Permits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SpaceId",
                table: "Tickets",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_SpaceId",
                table: "Permits",
                column: "SpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Spaces_SpaceId",
                table: "Permits",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Spaces_SpaceId",
                table: "Tickets",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Spaces_SpaceId",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Spaces_SpaceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SpaceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Permits_SpaceId",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "SpaceId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SpaceId",
                table: "Permits");
        }
    }
}
