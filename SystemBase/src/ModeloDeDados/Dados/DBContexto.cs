using Microsoft.EntityFrameworkCore;
using ModeloDeDados.Classes;

namespace ModeloDeDados.Dados
{
    public class DBContexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cep> Ceps { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Cotato> Contatos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=GUSTAVO-PC\SQLEXPRESS;Database=SISTEMBASE;Trusted_Connection=True;");

        }
    }
}
