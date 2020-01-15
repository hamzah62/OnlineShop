using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class DodanaKategorijaUArtikal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "Artikal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_KategorijaID",
                table: "Artikal",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_Kategorija_KategorijaID",
                table: "Artikal",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_Kategorija_KategorijaID",
                table: "Artikal");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_KategorijaID",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "Artikal");
        }
    }
}
