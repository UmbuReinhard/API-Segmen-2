using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changerelasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Profilings_NIK",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings",
                column: "NIK",
                principalTable: "Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Accounts_NIK",
                table: "Profilings");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Profilings_NIK",
                table: "Accounts",
                column: "NIK",
                principalTable: "Profilings",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
