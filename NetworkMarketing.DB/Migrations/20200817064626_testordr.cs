using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkMarketing.DB.Migrations
{
    public partial class testordr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderRow_Items_ItemId",
                table: "SalesOrderRow");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "SalesOrderRow",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderRow_Items_ItemId",
                table: "SalesOrderRow",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderRow_Items_ItemId",
                table: "SalesOrderRow");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "SalesOrderRow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderRow_Items_ItemId",
                table: "SalesOrderRow",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
