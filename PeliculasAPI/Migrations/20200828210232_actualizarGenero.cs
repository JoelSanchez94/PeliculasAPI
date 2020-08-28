using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasAPI.Migrations
{
    public partial class actualizarGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Generos",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 40);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                table: "Generos",
                type: "int",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
