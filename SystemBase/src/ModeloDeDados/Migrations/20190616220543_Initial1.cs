using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CidadeId",
                table: "Pessoas",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidades_CidadeId",
                table: "Pessoas",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "CidadeId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidades_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CidadeId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Pessoas");
        }
    }
}
