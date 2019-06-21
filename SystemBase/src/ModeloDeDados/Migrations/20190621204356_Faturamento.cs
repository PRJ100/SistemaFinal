using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDeDados.Migrations
{
    public partial class Faturamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faturamentos",
                columns: table => new
                {
                    FaturamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 20, nullable: true),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    HorarioConsuta = table.Column<string>(maxLength: 20, nullable: true),
                    MedicoId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    PlanoId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 30, nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoPagamento = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturamentos", x => x.FaturamentoId);
                    table.ForeignKey(
                        name: "FK_Faturamentos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faturamentos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faturamentos_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "PlanoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faturamentos_MedicoId",
                table: "Faturamentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturamentos_PessoaId",
                table: "Faturamentos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturamentos_PlanoId",
                table: "Faturamentos",
                column: "PlanoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faturamentos");
        }
    }
}
