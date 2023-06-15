using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopet___Alura_Challenge_6.Migrations
{
    public partial class Remapeandorelacionamentoentreentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Adocoes_PetId",
                table: "Adocoes",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adocoes_TutorId",
                table: "Adocoes",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocoes_Pets_PetId",
                table: "Adocoes",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adocoes_Tutores_TutorId",
                table: "Adocoes",
                column: "TutorId",
                principalTable: "Tutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocoes_Pets_PetId",
                table: "Adocoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Adocoes_Tutores_TutorId",
                table: "Adocoes");

            migrationBuilder.DropIndex(
                name: "IX_Adocoes_PetId",
                table: "Adocoes");

            migrationBuilder.DropIndex(
                name: "IX_Adocoes_TutorId",
                table: "Adocoes");
        }
    }
}
