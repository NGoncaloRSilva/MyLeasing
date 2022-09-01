using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLeasing.Common.Migrations
{
    public partial class ImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Lessees");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Lessees",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Lessees");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Lessees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
