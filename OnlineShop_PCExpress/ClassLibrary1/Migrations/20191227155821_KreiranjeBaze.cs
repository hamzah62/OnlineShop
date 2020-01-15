using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class KreiranjeBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podkategorija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    KategorijaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podkategorija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Podkategorija_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Popust = table.Column<double>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: false),
                    PodkategorijaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artikal_Podkategorija_PodkategorijaID",
                        column: x => x.PodkategorijaID,
                        principalTable: "Podkategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_PodkategorijaID",
                table: "Artikal",
                column: "PodkategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Podkategorija_KategorijaID",
                table: "Podkategorija",
                column: "KategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Podkategorija");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
