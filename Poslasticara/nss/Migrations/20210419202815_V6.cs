using Microsoft.EntityFrameworkCore.Migrations;

namespace nss.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoId",
                table: "Narudzbina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoId",
                table: "Narudzbina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
