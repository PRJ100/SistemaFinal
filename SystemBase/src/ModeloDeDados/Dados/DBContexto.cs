﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<ContasReceber> ContasReceber { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Faturamento> Faturamentos { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DEAN\SQLEXPRESS;Database=SISTEMBASE;Trusted_Connection=True;");

        }
    }
}
