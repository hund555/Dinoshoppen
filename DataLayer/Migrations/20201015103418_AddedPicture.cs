using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "DinoPicture",
                table: "Dinosaurs",
                nullable: true,
                defaultValue: "~/img/Default.jpg");

            migrationBuilder.AddColumn<int>(
                name: "Amound",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "DinoPicture",
                value: "~/img/Default.jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "DinoPicture",
                value: "~/img/Default.jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "DinoPicture",
                value: "~/img/Default.jpg");

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "DinoPicture",
                value: "~/img/Default.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DinoPicture",
                table: "Dinosaurs");

            migrationBuilder.DropColumn(
                name: "Amound",
                table: "Cart");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Cart",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
