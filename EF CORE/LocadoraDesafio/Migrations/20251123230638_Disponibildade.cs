using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDesafio.Migrations
{
    public partial class Disponibildade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponilidade",
                table: "Jogos",
                newName: "Disponibilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponibilidade",
                table: "Jogos",
                newName: "Disponilidade");
        }
    }
}
