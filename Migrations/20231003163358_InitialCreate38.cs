using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscoveryZoneApi.Migrations
{
    public partial class InitialCreate38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "TypeDate",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeDate",
                table: "Cards");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Subscriptions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
