using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementDataStore.Migrations
{
    public partial class FourthDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_storeProductId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "storeProductId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_storeProductId",
                table: "Products",
                column: "storeProductId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_storeProductId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "storeProductId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_storeProductId",
                table: "Products",
                column: "storeProductId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
