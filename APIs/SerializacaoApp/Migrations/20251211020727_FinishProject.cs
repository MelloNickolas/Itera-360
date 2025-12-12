using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerializacaoApp.Migrations
{
    public partial class FinishProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Itens_IDItem",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Usuarios_IDUsuario",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_IDItem",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_IDUsuario",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "DataDevolucao",
                table: "Emprestimos",
                newName: "DataDevolucaoPrevista");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Devolvido",
                table: "Emprestimos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucaoReal",
                table: "Emprestimos",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucaoReal",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "DataDevolucaoPrevista",
                table: "Emprestimos",
                newName: "DataDevolucao");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "Devolvido",
                table: "Emprestimos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_IDItem",
                table: "Emprestimos",
                column: "IDItem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_IDUsuario",
                table: "Emprestimos",
                column: "IDUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Itens_IDItem",
                table: "Emprestimos",
                column: "IDItem",
                principalTable: "Itens",
                principalColumn: "IDItem",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Usuarios_IDUsuario",
                table: "Emprestimos",
                column: "IDUsuario",
                principalTable: "Usuarios",
                principalColumn: "IDUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
