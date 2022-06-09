using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class hapuscolumnid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccountRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AccountRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
