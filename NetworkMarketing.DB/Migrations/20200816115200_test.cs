using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkMarketing.DB.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "Distributors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_DistributorId",
                table: "Distributors",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Distributors_DistributorId",
                table: "Distributors",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Distributors_DistributorId",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_DistributorId",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Distributors");
        }
    }
}
