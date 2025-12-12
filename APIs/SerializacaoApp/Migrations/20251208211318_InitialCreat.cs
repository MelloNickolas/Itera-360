using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerializacaoApp.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Itens_IDItem",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Emprestimos_IDEmprestimo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IDEmprestimo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IDEmprestimo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IDEmprestimo",
                table: "Itens");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Emprestimos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmprestimo",
                table: "Emprestimos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Devolvido",
                table: "Emprestimos",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Itens_IDItem",
                table: "Emprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Usuarios_IDUsuario",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_IDUsuario",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "DataEmprestimo",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "Devolvido",
                table: "Emprestimos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IDEmprestimo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IDEmprestimo",
                table: "Itens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDEmprestimo",
                table: "Usuarios",
                column: "IDEmprestimo",
                unique: true,
                filter: "[IDEmprestimo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Itens_IDItem",
                table: "Emprestimos",
                column: "IDItem",
                principalTable: "Itens",
                principalColumn: "IDItem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Emprestimos_IDEmprestimo",
                table: "Usuarios",
                column: "IDEmprestimo",
                principalTable: "Emprestimos",
                principalColumn: "IDEmprestimo");
        }
    }
}
