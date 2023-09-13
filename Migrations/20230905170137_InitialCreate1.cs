using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscoveryZoneApi.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "discount",
                table: "Offers",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Offers",
                newName: "DescEng");

            migrationBuilder.AddColumn<string>(
                name: "DescAr",
                table: "Offers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescAr",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Offers",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "DescEng",
                table: "Offers",
                newName: "Desc");
        }
    }
}
