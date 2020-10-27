using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Removed_DefaultPicturePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DinoPicture",
                table: "Dinosaurs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "~/img/Default.jpg");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DinoPicture",
                table: "Dinosaurs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "~/img/Default.jpg",
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
