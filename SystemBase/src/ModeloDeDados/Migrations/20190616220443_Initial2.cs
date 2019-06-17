using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas");

            migrationBuilder.AlterColumn<int>(
                name: "CepId",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas",
                column: "CepId",
                principalTable: "Ceps",
                principalColumn: "CepId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas");

            migrationBuilder.AlterColumn<int>(
                name: "CepId",
                table: "Pessoas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas",
                column: "CepId",
                principalTable: "Ceps",
                principalColumn: "CepId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
