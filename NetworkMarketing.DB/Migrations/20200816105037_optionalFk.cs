using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkMarketing.DB.Migrations
{
    public partial class optionalFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_AddressInfo_AddressInfoId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_ContactInfo_ContactInfoId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_IdentityInfo_IdentityInfoId",
                table: "Distributors");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityInfoId",
                table: "Distributors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoId",
                table: "Distributors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressInfoId",
                table: "Distributors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_AddressInfo_AddressInfoId",
                table: "Distributors",
                column: "AddressInfoId",
                principalTable: "AddressInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_ContactInfo_ContactInfoId",
                table: "Distributors",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_IdentityInfo_IdentityInfoId",
                table: "Distributors",
                column: "IdentityInfoId",
                principalTable: "IdentityInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_AddressInfo_AddressInfoId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_ContactInfo_ContactInfoId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_IdentityInfo_IdentityInfoId",
                table: "Distributors");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityInfoId",
                table: "Distributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoId",
                table: "Distributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AddressInfoId",
                table: "Distributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_AddressInfo_AddressInfoId",
                table: "Distributors",
                column: "AddressInfoId",
                principalTable: "AddressInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_ContactInfo_ContactInfoId",
                table: "Distributors",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_IdentityInfo_IdentityInfoId",
                table: "Distributors",
                column: "IdentityInfoId",
                principalTable: "IdentityInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
