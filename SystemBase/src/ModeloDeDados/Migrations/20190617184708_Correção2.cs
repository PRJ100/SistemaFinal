using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class Correção2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_ContatoId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "ContatoId",
                table: "Contatos",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Contatos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "ContatoId",
                table: "Contatos",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_ContatoId",
                table: "Contatos",
                column: "ContatoId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
