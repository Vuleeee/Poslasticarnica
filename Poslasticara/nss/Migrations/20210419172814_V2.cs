using Microsoft.EntityFrameworkCore.Migrations;

namespace nss.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbina_Poslasticara_PoslasticaraID",
                table: "Narudzbina");

            migrationBuilder.RenameColumn(
                name: "PoslasticaraID",
                table: "Narudzbina",
                newName: "StoloveID");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzbina_PoslasticaraID",
                table: "Narudzbina",
                newName: "IX_Narudzbina_StoloveID");

            migrationBuilder.AddColumn<int>(
                name: "StoId",
                table: "Narudzbina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbina_Stolovi_StoloveID",
                table: "Narudzbina",
                column: "StoloveID",
                principalTable: "Stolovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbina_Stolovi_StoloveID",
                table: "Narudzbina");

            migrationBuilder.DropColumn(
                name: "StoId",
                table: "Narudzbina");

            migrationBuilder.RenameColumn(
                name: "StoloveID",
                table: "Narudzbina",
                newName: "PoslasticaraID");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzbina_StoloveID",
                table: "Narudzbina",
                newName: "IX_Narudzbina_PoslasticaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbina_Poslasticara_PoslasticaraID",
                table: "Narudzbina",
                column: "PoslasticaraID",
                principalTable: "Poslasticara",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
