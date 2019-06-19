using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class CriarTabelasContasAPagarEAReceber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasPagar",
                columns: table => new
                {
                    ContasPagarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ_CPF = table.Column<string>(maxLength: 20, nullable: true),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    FormaPagamento = table.Column<string>(maxLength: 30, nullable: true),
                    Contato = table.Column<string>(maxLength: 20, nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagar", x => x.ContasPagarId);
                });

            migrationBuilder.CreateTable(
                name: "ContasReceber",
                columns: table => new
                {
                    ContasReceberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ_CPF = table.Column<string>(maxLength: 20, nullable: true),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    FormaPagamento = table.Column<string>(nullable: true),
                    Contato = table.Column<string>(maxLength: 20, nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReceber", x => x.ContasReceberId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasPagar");

            migrationBuilder.DropTable(
                name: "ContasReceber");
        }
    }
}
