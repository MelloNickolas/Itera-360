using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerializacaoApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    IDItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IDEmprestimo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.IDItem);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    IDEmprestimo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    IDItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.IDEmprestimo);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Itens_IDItem",
                        column: x => x.IDItem,
                        principalTable: "Itens",
                        principalColumn: "IDItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDEmprestimo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Emprestimos_IDEmprestimo",
                        column: x => x.IDEmprestimo,
                        principalTable: "Emprestimos",
                        principalColumn: "IDEmprestimo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_IDItem",
                table: "Emprestimos",
                column: "IDItem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDEmprestimo",
                table: "Usuarios",
                column: "IDEmprestimo",
                unique: true,
                filter: "[IDEmprestimo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Itens");
        }
    }
}
