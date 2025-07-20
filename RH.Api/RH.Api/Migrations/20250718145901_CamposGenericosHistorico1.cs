using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Api.Migrations
{
    /// <inheritdoc />
    public partial class CamposGenericosHistorico1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historicos_Funcionarios_FuncionarioId",
                table: "Historicos");

            migrationBuilder.DropIndex(
                name: "IX_Historicos_FuncionarioId",
                table: "Historicos");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Historicos",
                newName: "RegistroChave");

            migrationBuilder.AddColumn<string>(
                name: "NomeEntidade",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeEntidade",
                table: "Historicos");

            migrationBuilder.RenameColumn(
                name: "RegistroChave",
                table: "Historicos",
                newName: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_FuncionarioId",
                table: "Historicos",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historicos_Funcionarios_FuncionarioId",
                table: "Historicos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
