using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGenius.Migrations
{
    /// <inheritdoc />
    public partial class CpfCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CpfCliente",
                table: "Scripts",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorProduto",
                table: "Produtos",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCliente",
                table: "Scripts");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorProduto",
                table: "Produtos",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
