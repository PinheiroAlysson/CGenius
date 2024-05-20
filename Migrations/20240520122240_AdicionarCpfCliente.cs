using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGenius.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCpfCliente : Migration
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
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCliente",
                table: "Scripts");
        }
    }
}
