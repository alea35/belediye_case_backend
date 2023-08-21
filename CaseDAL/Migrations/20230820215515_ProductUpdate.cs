using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseDAL.Migrations
{
    public partial class ProductUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("49d2c593-5c5e-4046-a984-c94c02024162"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5745), "En kaliteli telefonlar", false, null, "Telefon" },
                    { new Guid("a3869bda-8c5a-4732-8687-f4fb92978fa1"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5749), "En kaliteli bilgisayarlar", false, null, "Bilgisayar" },
                    { new Guid("c807175e-f87f-467a-b3b9-b32a5f5bc43b"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5748), "En kaliteli tabletler", false, null, "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedOn", "Password" },
                values: new object[] { new Guid("61727065-8e2f-43fe-9334-ab80f32a13ea"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5875), "aliiakcekoca@gmail.com", "Ali", false, "Akçekoce", null, "qwerty12-" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsDeleted", "ModifiedOn", "Name", "Price", "Quantity", "Unit" },
                values: new object[,]
                {
                    { new Guid("07487811-8537-4ec6-b9aa-a980e76ead12"), new Guid("a3869bda-8c5a-4732-8687-f4fb92978fa1"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5860), "Oyun bilgisayarı", "6.jpg", false, null, "Monster Abra", 36000f, 5f, "ADET" },
                    { new Guid("15691289-8f57-47a8-aad9-0680e243a499"), new Guid("c807175e-f87f-467a-b3b9-b32a5f5bc43b"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5844), "Çocuklar için tablet", "3.jpg", false, null, "Galaxy TAB S7", 20000f, 3f, "ADET" },
                    { new Guid("24262ab2-8372-41f8-808e-c386b779da42"), new Guid("a3869bda-8c5a-4732-8687-f4fb92978fa1"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5858), "İş bilgisayarı", "5.jpg", false, null, "Hp Envy", 66000f, 5f, "ADET" },
                    { new Guid("4aef8c02-8012-4663-a6f0-c677cc81de11"), new Guid("49d2c593-5c5e-4046-a984-c94c02024162"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5843), "Güncel telefon", "2.jpg", false, null, "Iphone 13 ", 46000f, 15f, "ADET" },
                    { new Guid("6452d99e-426d-4a3a-ba62-27bdcbd0f126"), new Guid("49d2c593-5c5e-4046-a984-c94c02024162"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5840), "En sağlam telefon", "1.jpg", false, null, "Iphone 14 Pro", 56000f, 5f, "ADET" },
                    { new Guid("6e3ad4c6-f92b-4c29-87b6-ae15736377b7"), new Guid("c807175e-f87f-467a-b3b9-b32a5f5bc43b"), new DateTime(2023, 8, 20, 21, 55, 15, 256, DateTimeKind.Utc).AddTicks(5846), "İş tableti", "4.jpg", false, null, "Matepad SE", 25000f, 35f, "ADET" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
