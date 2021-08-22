using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementDataStore.Migrations
{
    public partial class ThirdDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customersId",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    storeProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Stores_storeProductId",
                        column: x => x.storeProductId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_customersId",
                table: "Stores",
                column: "customersId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_storeProductId",
                table: "Products",
                column: "storeProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Customers_customersId",
                table: "Stores",
                column: "customersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Customers_customersId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Stores_customersId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "customersId",
                table: "Stores");
        }
    }
}
