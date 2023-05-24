using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopet___Alura_Challenge_6.Migrations
{
    public partial class adicionandorelacaopeteabrigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbrigoId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Adotado",
                table: "Pets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Pets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AbrigoId",
                table: "Pets",
                column: "AbrigoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Abrigos_AbrigoId",
                table: "Pets",
                column: "AbrigoId",
                principalTable: "Abrigos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Abrigos_AbrigoId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AbrigoId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AbrigoId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Adotado",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Pets");
        }
    }
}
