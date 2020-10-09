using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class added_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "promotionName",
                table: "Promotions",
                newName: "PromotionName");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Rabats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Promotions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Mail", "Name" },
                values: new object[,]
                {
                    { 1, "Sønderborgvej 1", "customer1@gmail.com", "Customer1" },
                    { 2, "Sønderborgvej 2", "customer2@gmail.com", "Customer2" },
                    { 3, "Sønderborgvej 3", "customer3@gmail.com", "Customer3" },
                    { 4, "Sønderborgvej 4", "customer4@gmail.com", "Customer4" }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietId", "DietName" },
                values: new object[,]
                {
                    { 1, "Carnivore" },
                    { 2, "Herbivore" },
                    { 3, "Omnivore" }
                });

            migrationBuilder.InsertData(
                table: "Dinosaurs",
                columns: new[] { "DinosaurId", "DietId", "DinoHeight", "DinoLenght", "DinoName", "DinoPrice", "DinoWeight", "PromotionId" },
                values: new object[,]
                {
                    { 1, 1, 6.0999999999999996, 13.0, "Tyrannosaurus Rex", 11650000.0, 14000.0, null },
                    { 2, 1, 3.0, 9.0, "Carnotaurus", 3500000.0, 3000.0, null },
                    { 3, 2, 6.0, 22.0, "Brontosaurus", 15000000.0, 15000.0, null },
                    { 4, 3, 4.5, 3.7999999999999998, "Ornithomimus", 365000.0, 170.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Mail",
                table: "Customers",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Mail",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "DinosaurId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diet",
                keyColumn: "DietId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diet",
                keyColumn: "DietId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diet",
                keyColumn: "DietId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Rabats");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "PromotionName",
                table: "Promotions",
                newName: "promotionName");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
