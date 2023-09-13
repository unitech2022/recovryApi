using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscoveryZoneApi.Migrations
{
    public partial class InitialCreate33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subscriptions",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Subscriptions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Subscriptions",
                newName: "Name");
        }
    }
}
