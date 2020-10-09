using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Added_PromotionSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "PromotionId", "PromotionName", "PromotionRabat" },
                values: new object[] { 1, "Åbnings salg", 25 });

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "PromotionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "PromotionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "PromotionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "PromotionId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3,
                column: "PromotionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4,
                column: "PromotionId",
                value: null);
        }
    }
}
