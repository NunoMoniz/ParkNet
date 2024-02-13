using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.App.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var roleBuilder = new Microsoft.AspNetCore.Identity.IdentityRole("Admin");

            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('" + roleBuilder.Id + "', '" + roleBuilder.Name + "', '" + roleBuilder.NormalizedName + "', '" + roleBuilder.ConcurrencyStamp + "')");
        }
    }
}
