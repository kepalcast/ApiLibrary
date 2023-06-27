using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLibrary.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    AutorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LibName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPaginas = table.Column<int>(type: "int", nullable: false),
                    AutoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_libros_autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "autores",
                columns: new[] { "IdAutor", "AutorName", "FechaNacimiento" },
                values: new object[] { 1, "Ruben Darío", new DateTime(1980, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "autores",
                columns: new[] { "IdAutor", "AutorName", "FechaNacimiento" },
                values: new object[] { 2, "Alvaro cochon", new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "ISBN", "AutoresId", "LibName", "numPaginas" },
                values: new object[] { "001-1023M", 2, "La joyita", 342 });

            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "ISBN", "AutoresId", "LibName", "numPaginas" },
                values: new object[] { "453-2398N", 1, "180 dias", 500 });

            migrationBuilder.CreateIndex(
                name: "IX_libros_AutoresId",
                table: "libros",
                column: "AutoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "autores");
        }
    }
}
