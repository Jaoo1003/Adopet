using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdopetUsuario.Migrations
{
    public partial class adicionandorolecadastrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a2ae074b-5bcc-4de3-8832-3f1c046f89b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b788a7d1-f363-407a-9625-8d80fbfe066f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "b603bb3d-a64a-49fc-bce1-92ff4ebe8c40", "Cadastrado", "CADASTRADO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "03407d71-6354-4085-8129-e3b0ff9ed8e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3b98e594-6bfa-45f3-a38f-88d66948e7d7");
        }
    }
}
