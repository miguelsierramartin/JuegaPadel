using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
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
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 557m },
                    { 73, "Description for product 73", "Product 73", 787m },
                    { 72, "Description for product 72", "Product 72", 227m },
                    { 71, "Description for product 71", "Product 71", 653m },
                    { 70, "Description for product 70", "Product 70", 713m },
                    { 69, "Description for product 69", "Product 69", 832m },
                    { 68, "Description for product 68", "Product 68", 763m },
                    { 67, "Description for product 67", "Product 67", 869m },
                    { 66, "Description for product 66", "Product 66", 397m },
                    { 65, "Description for product 65", "Product 65", 111m },
                    { 64, "Description for product 64", "Product 64", 671m },
                    { 63, "Description for product 63", "Product 63", 569m },
                    { 62, "Description for product 62", "Product 62", 365m },
                    { 61, "Description for product 61", "Product 61", 419m },
                    { 60, "Description for product 60", "Product 60", 399m },
                    { 59, "Description for product 59", "Product 59", 800m },
                    { 58, "Description for product 58", "Product 58", 506m },
                    { 57, "Description for product 57", "Product 57", 989m },
                    { 56, "Description for product 56", "Product 56", 294m },
                    { 55, "Description for product 55", "Product 55", 345m },
                    { 54, "Description for product 54", "Product 54", 851m },
                    { 53, "Description for product 53", "Product 53", 707m },
                    { 74, "Description for product 74", "Product 74", 261m },
                    { 52, "Description for product 52", "Product 52", 352m },
                    { 75, "Description for product 75", "Product 75", 762m },
                    { 77, "Description for product 77", "Product 77", 795m },
                    { 98, "Description for product 98", "Product 98", 896m },
                    { 97, "Description for product 97", "Product 97", 649m },
                    { 96, "Description for product 96", "Product 96", 316m },
                    { 95, "Description for product 95", "Product 95", 532m },
                    { 94, "Description for product 94", "Product 94", 219m },
                    { 93, "Description for product 93", "Product 93", 205m },
                    { 92, "Description for product 92", "Product 92", 804m },
                    { 91, "Description for product 91", "Product 91", 556m },
                    { 90, "Description for product 90", "Product 90", 973m },
                    { 89, "Description for product 89", "Product 89", 737m },
                    { 88, "Description for product 88", "Product 88", 152m },
                    { 87, "Description for product 87", "Product 87", 510m },
                    { 86, "Description for product 86", "Product 86", 260m },
                    { 85, "Description for product 85", "Product 85", 456m },
                    { 84, "Description for product 84", "Product 84", 963m },
                    { 83, "Description for product 83", "Product 83", 529m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for product 82", "Product 82", 337m },
                    { 81, "Description for product 81", "Product 81", 682m },
                    { 80, "Description for product 80", "Product 80", 430m },
                    { 79, "Description for product 79", "Product 79", 266m },
                    { 78, "Description for product 78", "Product 78", 391m },
                    { 76, "Description for product 76", "Product 76", 282m },
                    { 51, "Description for product 51", "Product 51", 379m },
                    { 50, "Description for product 50", "Product 50", 560m },
                    { 49, "Description for product 49", "Product 49", 146m },
                    { 22, "Description for product 22", "Product 22", 363m },
                    { 21, "Description for product 21", "Product 21", 401m },
                    { 20, "Description for product 20", "Product 20", 344m },
                    { 19, "Description for product 19", "Product 19", 113m },
                    { 18, "Description for product 18", "Product 18", 306m },
                    { 17, "Description for product 17", "Product 17", 133m },
                    { 16, "Description for product 16", "Product 16", 864m },
                    { 15, "Description for product 15", "Product 15", 259m },
                    { 14, "Description for product 14", "Product 14", 101m },
                    { 13, "Description for product 13", "Product 13", 746m },
                    { 12, "Description for product 12", "Product 12", 773m },
                    { 11, "Description for product 11", "Product 11", 514m },
                    { 10, "Description for product 10", "Product 10", 525m },
                    { 9, "Description for product 9", "Product 9", 407m },
                    { 8, "Description for product 8", "Product 8", 993m },
                    { 7, "Description for product 7", "Product 7", 841m },
                    { 6, "Description for product 6", "Product 6", 204m },
                    { 5, "Description for product 5", "Product 5", 256m },
                    { 4, "Description for product 4", "Product 4", 865m },
                    { 3, "Description for product 3", "Product 3", 516m },
                    { 2, "Description for product 2", "Product 2", 276m },
                    { 23, "Description for product 23", "Product 23", 287m },
                    { 24, "Description for product 24", "Product 24", 110m },
                    { 25, "Description for product 25", "Product 25", 165m },
                    { 26, "Description for product 26", "Product 26", 857m },
                    { 48, "Description for product 48", "Product 48", 547m },
                    { 47, "Description for product 47", "Product 47", 275m },
                    { 46, "Description for product 46", "Product 46", 734m },
                    { 45, "Description for product 45", "Product 45", 844m },
                    { 44, "Description for product 44", "Product 44", 896m },
                    { 43, "Description for product 43", "Product 43", 568m },
                    { 42, "Description for product 42", "Product 42", 219m },
                    { 41, "Description for product 41", "Product 41", 582m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for product 40", "Product 40", 851m },
                    { 39, "Description for product 39", "Product 39", 518m },
                    { 99, "Description for product 99", "Product 99", 884m },
                    { 38, "Description for product 38", "Product 38", 905m },
                    { 36, "Description for product 36", "Product 36", 545m },
                    { 35, "Description for product 35", "Product 35", 268m },
                    { 34, "Description for product 34", "Product 34", 982m },
                    { 33, "Description for product 33", "Product 33", 903m },
                    { 32, "Description for product 32", "Product 32", 217m },
                    { 31, "Description for product 31", "Product 31", 513m },
                    { 30, "Description for product 30", "Product 30", 735m },
                    { 29, "Description for product 29", "Product 29", 523m },
                    { 28, "Description for product 28", "Product 28", 576m },
                    { 27, "Description for product 27", "Product 27", 785m },
                    { 37, "Description for product 37", "Product 37", 310m },
                    { 100, "Description for product 100", "Product 100", 546m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 15 },
                    { 73, 73, 9 },
                    { 72, 72, 18 },
                    { 71, 71, 12 },
                    { 70, 70, 4 },
                    { 69, 69, 4 },
                    { 68, 68, 14 },
                    { 67, 67, 0 },
                    { 66, 66, 0 },
                    { 65, 65, 5 },
                    { 64, 64, 2 },
                    { 63, 63, 11 },
                    { 62, 62, 4 },
                    { 61, 61, 18 },
                    { 60, 60, 1 },
                    { 59, 59, 11 },
                    { 58, 58, 3 },
                    { 57, 57, 14 },
                    { 56, 56, 12 },
                    { 55, 55, 14 },
                    { 54, 54, 19 },
                    { 53, 53, 19 },
                    { 74, 74, 16 },
                    { 52, 52, 19 },
                    { 75, 75, 16 },
                    { 77, 77, 14 },
                    { 98, 98, 5 },
                    { 97, 97, 3 },
                    { 96, 96, 14 },
                    { 95, 95, 8 },
                    { 94, 94, 14 },
                    { 93, 93, 12 },
                    { 92, 92, 2 },
                    { 91, 91, 7 },
                    { 90, 90, 13 },
                    { 89, 89, 7 },
                    { 88, 88, 19 },
                    { 87, 87, 1 },
                    { 86, 86, 6 },
                    { 85, 85, 4 },
                    { 84, 84, 16 },
                    { 83, 83, 13 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 11 },
                    { 81, 81, 17 },
                    { 80, 80, 18 },
                    { 79, 79, 17 },
                    { 78, 78, 16 },
                    { 76, 76, 18 },
                    { 51, 51, 11 },
                    { 50, 50, 8 },
                    { 49, 49, 16 },
                    { 22, 22, 2 },
                    { 21, 21, 13 },
                    { 20, 20, 15 },
                    { 19, 19, 3 },
                    { 18, 18, 5 },
                    { 17, 17, 2 },
                    { 16, 16, 17 },
                    { 15, 15, 6 },
                    { 14, 14, 10 },
                    { 13, 13, 16 },
                    { 12, 12, 19 },
                    { 11, 11, 1 },
                    { 10, 10, 11 },
                    { 9, 9, 18 },
                    { 8, 8, 17 },
                    { 7, 7, 15 },
                    { 6, 6, 19 },
                    { 5, 5, 0 },
                    { 4, 4, 10 },
                    { 3, 3, 0 },
                    { 2, 2, 19 },
                    { 23, 23, 5 },
                    { 24, 24, 17 },
                    { 25, 25, 18 },
                    { 26, 26, 18 },
                    { 48, 48, 8 },
                    { 47, 47, 1 },
                    { 46, 46, 0 },
                    { 45, 45, 0 },
                    { 44, 44, 8 },
                    { 43, 43, 7 },
                    { 42, 42, 15 },
                    { 41, 41, 18 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 7 },
                    { 39, 39, 15 },
                    { 99, 99, 2 },
                    { 38, 38, 4 },
                    { 36, 36, 1 },
                    { 35, 35, 5 },
                    { 34, 34, 1 },
                    { 33, 33, 18 },
                    { 32, 32, 0 },
                    { 31, 31, 5 },
                    { 30, 30, 16 },
                    { 29, 29, 5 },
                    { 28, 28, 10 },
                    { 27, 27, 0 },
                    { 37, 37, 5 },
                    { 100, 100, 19 }
                });

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
