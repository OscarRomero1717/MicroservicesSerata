using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.PersistenceDataBase.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(maxLength: 100, nullable: false),
                    DescriptionProduct = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "DescriptionProduct", "NameProduct", "Price" },
                values: new object[,]
                {
                    { 1, "Description 1", "Product1", 238 },
                    { 72, "Description 72", "Product72", 92 },
                    { 71, "Description 71", "Product71", 118 },
                    { 70, "Description 70", "Product70", 55 },
                    { 69, "Description 69", "Product69", 50 },
                    { 68, "Description 68", "Product68", 363 },
                    { 67, "Description 67", "Product67", 52 },
                    { 66, "Description 66", "Product66", 202 },
                    { 65, "Description 65", "Product65", 79 },
                    { 64, "Description 64", "Product64", 113 },
                    { 63, "Description 63", "Product63", 45 },
                    { 62, "Description 62", "Product62", 483 },
                    { 61, "Description 61", "Product61", 384 },
                    { 60, "Description 60", "Product60", 114 },
                    { 59, "Description 59", "Product59", 442 },
                    { 58, "Description 58", "Product58", 380 },
                    { 57, "Description 57", "Product57", 271 },
                    { 56, "Description 56", "Product56", 50 },
                    { 55, "Description 55", "Product55", 451 },
                    { 54, "Description 54", "Product54", 394 },
                    { 53, "Description 53", "Product53", 121 },
                    { 52, "Description 52", "Product52", 175 },
                    { 73, "Description 73", "Product73", 273 },
                    { 51, "Description 51", "Product51", 444 },
                    { 74, "Description 74", "Product74", 240 },
                    { 76, "Description 76", "Product76", 168 },
                    { 97, "Description 97", "Product97", 29 },
                    { 96, "Description 96", "Product96", 289 },
                    { 95, "Description 95", "Product95", 239 },
                    { 94, "Description 94", "Product94", 354 },
                    { 93, "Description 93", "Product93", 341 },
                    { 92, "Description 92", "Product92", 82 },
                    { 91, "Description 91", "Product91", 89 },
                    { 90, "Description 90", "Product90", 136 },
                    { 89, "Description 89", "Product89", 499 },
                    { 88, "Description 88", "Product88", 118 },
                    { 87, "Description 87", "Product87", 230 },
                    { 86, "Description 86", "Product86", 283 },
                    { 85, "Description 85", "Product85", 237 },
                    { 84, "Description 84", "Product84", 496 },
                    { 83, "Description 83", "Product83", 236 },
                    { 82, "Description 82", "Product82", 249 },
                    { 81, "Description 81", "Product81", 20 },
                    { 80, "Description 80", "Product80", 421 },
                    { 79, "Description 79", "Product79", 59 },
                    { 78, "Description 78", "Product78", 476 },
                    { 77, "Description 77", "Product77", 485 },
                    { 75, "Description 75", "Product75", 489 },
                    { 98, "Description 98", "Product98", 91 },
                    { 50, "Description 50", "Product50", 431 },
                    { 48, "Description 48", "Product48", 97 },
                    { 22, "Description 22", "Product22", 189 },
                    { 21, "Description 21", "Product21", 241 },
                    { 20, "Description 20", "Product20", 262 },
                    { 19, "Description 19", "Product19", 363 },
                    { 18, "Description 18", "Product18", 240 },
                    { 17, "Description 17", "Product17", 375 },
                    { 16, "Description 16", "Product16", 81 },
                    { 15, "Description 15", "Product15", 414 },
                    { 14, "Description 14", "Product14", 234 },
                    { 13, "Description 13", "Product13", 314 },
                    { 12, "Description 12", "Product12", 64 },
                    { 11, "Description 11", "Product11", 53 },
                    { 10, "Description 10", "Product10", 37 },
                    { 9, "Description 9", "Product9", 294 },
                    { 8, "Description 8", "Product8", 472 },
                    { 7, "Description 7", "Product7", 48 },
                    { 6, "Description 6", "Product6", 229 },
                    { 5, "Description 5", "Product5", 39 },
                    { 4, "Description 4", "Product4", 140 },
                    { 3, "Description 3", "Product3", 37 },
                    { 2, "Description 2", "Product2", 226 },
                    { 23, "Description 23", "Product23", 454 },
                    { 49, "Description 49", "Product49", 328 },
                    { 24, "Description 24", "Product24", 157 },
                    { 26, "Description 26", "Product26", 425 },
                    { 47, "Description 47", "Product47", 405 },
                    { 46, "Description 46", "Product46", 276 },
                    { 45, "Description 45", "Product45", 98 },
                    { 44, "Description 44", "Product44", 477 },
                    { 43, "Description 43", "Product43", 204 },
                    { 42, "Description 42", "Product42", 74 },
                    { 41, "Description 41", "Product41", 272 },
                    { 40, "Description 40", "Product40", 123 },
                    { 39, "Description 39", "Product39", 467 },
                    { 38, "Description 38", "Product38", 283 },
                    { 37, "Description 37", "Product37", 462 },
                    { 36, "Description 36", "Product36", 359 },
                    { 35, "Description 35", "Product35", 185 },
                    { 34, "Description 34", "Product34", 450 },
                    { 33, "Description 33", "Product33", 13 },
                    { 32, "Description 32", "Product32", 350 },
                    { 31, "Description 31", "Product31", 458 },
                    { 30, "Description 30", "Product30", 181 },
                    { 29, "Description 29", "Product29", 427 },
                    { 28, "Description 28", "Product28", 64 },
                    { 27, "Description 27", "Product27", 345 },
                    { 25, "Description 25", "Product25", 198 },
                    { 99, "Description 99", "Product99", 398 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 28 },
                    { 72, 72, 28 },
                    { 71, 71, 5 },
                    { 70, 70, 54 },
                    { 69, 69, 26 },
                    { 68, 68, 7 },
                    { 67, 67, 74 },
                    { 66, 66, 23 },
                    { 65, 65, 30 },
                    { 64, 64, 33 },
                    { 63, 63, 80 },
                    { 62, 62, 41 },
                    { 61, 61, 21 },
                    { 60, 60, 75 },
                    { 59, 59, 4 },
                    { 58, 58, 82 },
                    { 57, 57, 53 },
                    { 56, 56, 86 },
                    { 55, 55, 69 },
                    { 54, 54, 19 },
                    { 53, 53, 89 },
                    { 52, 52, 30 },
                    { 73, 73, 52 },
                    { 51, 51, 5 },
                    { 74, 74, 62 },
                    { 76, 76, 25 },
                    { 97, 97, 77 },
                    { 96, 96, 98 },
                    { 95, 95, 52 },
                    { 94, 94, 48 },
                    { 93, 93, 53 },
                    { 92, 92, 16 },
                    { 91, 91, 32 },
                    { 90, 90, 17 },
                    { 89, 89, 92 },
                    { 88, 88, 72 },
                    { 87, 87, 32 },
                    { 86, 86, 73 },
                    { 85, 85, 79 },
                    { 84, 84, 93 },
                    { 83, 83, 89 },
                    { 82, 82, 18 },
                    { 81, 81, 67 },
                    { 80, 80, 22 },
                    { 79, 79, 43 },
                    { 78, 78, 26 },
                    { 77, 77, 90 },
                    { 75, 75, 18 },
                    { 98, 98, 18 },
                    { 50, 50, 97 },
                    { 48, 48, 85 },
                    { 22, 22, 42 },
                    { 21, 21, 82 },
                    { 20, 20, 59 },
                    { 19, 19, 36 },
                    { 18, 18, 77 },
                    { 17, 17, 86 },
                    { 16, 16, 4 },
                    { 15, 15, 40 },
                    { 14, 14, 30 },
                    { 13, 13, 69 },
                    { 12, 12, 66 },
                    { 11, 11, 45 },
                    { 10, 10, 34 },
                    { 9, 9, 18 },
                    { 8, 8, 71 },
                    { 7, 7, 46 },
                    { 6, 6, 25 },
                    { 5, 5, 36 },
                    { 4, 4, 64 },
                    { 3, 3, 97 },
                    { 2, 2, 35 },
                    { 23, 23, 81 },
                    { 49, 49, 14 },
                    { 24, 24, 14 },
                    { 26, 26, 61 },
                    { 47, 47, 93 },
                    { 46, 46, 37 },
                    { 45, 45, 71 },
                    { 44, 44, 54 },
                    { 43, 43, 51 },
                    { 42, 42, 57 },
                    { 41, 41, 40 },
                    { 40, 40, 73 },
                    { 39, 39, 24 },
                    { 38, 38, 57 },
                    { 37, 37, 99 },
                    { 36, 36, 86 },
                    { 35, 35, 3 },
                    { 34, 34, 61 },
                    { 33, 33, 92 },
                    { 32, 32, 21 },
                    { 31, 31, 3 },
                    { 30, 30, 84 },
                    { 29, 29, 91 },
                    { 28, 28, 4 },
                    { 27, 27, 4 },
                    { 25, 25, 59 },
                    { 99, 99, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
