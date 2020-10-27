using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Removed_pictureFromSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "DinoPicture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "DinoPicture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "DinoPicture",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "DinoPicture",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "DinoPicture",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "DinoPicture",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "DinoPicture",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "DinoPicture",
                value: "jpg");
        }
    }
}
