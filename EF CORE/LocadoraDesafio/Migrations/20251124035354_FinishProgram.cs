using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDesafio.Migrations
{
    public partial class FinishProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDAluguel",
                table: "Jogos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    IDAluguel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAluguel = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.IDAluguel);
                    table.ForeignKey(
                        name: "FK_Alugueis_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_IDAluguel",
                table: "Jogos",
                column: "IDAluguel");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_IDCliente",
                table: "Alugueis",
                column: "IDCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Alugueis_IDAluguel",
                table: "Jogos",
                column: "IDAluguel",
                principalTable: "Alugueis",
                principalColumn: "IDAluguel",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Alugueis_IDAluguel",
                table: "Jogos");

            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_IDAluguel",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "IDAluguel",
                table: "Jogos");
        }
    }
}
