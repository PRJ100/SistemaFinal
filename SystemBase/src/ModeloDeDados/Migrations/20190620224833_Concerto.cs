using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class Concerto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "CepId",
                table: "Pessoas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CepRua",
                table: "Pessoas",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Crm",
                table: "Medicos",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Medicos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas",
                column: "CepId",
                principalTable: "Ceps",
                principalColumn: "CepId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "CepRua",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "CepId",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Crm",
                table: "Medicos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos",
                column: "Crm");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Ceps_CepId",
                table: "Pessoas",
                column: "CepId",
                principalTable: "Ceps",
                principalColumn: "CepId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
