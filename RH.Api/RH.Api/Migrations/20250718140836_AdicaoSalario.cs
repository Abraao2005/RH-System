using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoSalario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Funcionarios",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Funcionarios");
        }
    }
}
