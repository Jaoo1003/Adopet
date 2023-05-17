using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopet___Alura_Challenge_6.Migrations
{
    public partial class mapeandobancodedados2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tutores",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tutores",
                newName: "id");
        }
    }
}
