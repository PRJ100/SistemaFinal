﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModeloDeDados.Dados;

namespace ModeloDeDados.Migrations
{
    [DbContext(typeof(DBContexto))]
    partial class DBContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModeloDeDados.Classes.Banco", b =>
                {
                    b.Property<int>("BancoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.HasKey("BancoId");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Cep", b =>
                {
                    b.Property<int>("CepId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CidadeId");

                    b.Property<string>("NumeroCep")
                        .HasMaxLength(25);

                    b.HasKey("CepId");

                    b.HasIndex("CidadeId");

                    b.ToTable("Ceps");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoIBGE");

                    b.Property<int>("EstadoId");

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.HasKey("CidadeId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.ContaBancaria", b =>
                {
                    b.Property<int>("ContaBancariaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasMaxLength(15);

                    b.Property<int>("BancoId");

                    b.Property<string>("Conta")
                        .HasMaxLength(15);

                    b.Property<decimal>("Disponivel");

                    b.Property<decimal>("Limite");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<string>("Observacao")
                        .HasMaxLength(200);

                    b.Property<decimal>("Saldo");

                    b.HasKey("ContaBancariaId");

                    b.HasIndex("BancoId");

                    b.ToTable("ContasBancarias");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoIBGE");

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<int>("PaisId");

                    b.Property<string>("Sigla")
                        .HasMaxLength(2);

                    b.HasKey("EstadoId");

                    b.HasIndex("PaisId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Medicamento", b =>
                {
                    b.Property<int>("MedicamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<int>("NumeroRegistro");

                    b.HasKey("MedicamentoId");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Medico", b =>
                {
                    b.Property<int>("Crm");

                    b.Property<string>("Especialidade")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .HasMaxLength(20);

                    b.HasKey("Crm");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoTelefone");

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(100);

                    b.Property<string>("CPF")
                        .HasMaxLength(20);

                    b.Property<int>("CepId");

                    b.Property<int>("CidadeId");

                    b.Property<string>("Complemento")
                        .HasMaxLength(200);

                    b.Property<string>("Contato")
                        .HasMaxLength(80);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("EstadoCivil")
                        .HasMaxLength(50);

                    b.Property<int>("Idade");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Naturalidade")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("NomeMae")
                        .HasMaxLength(100);

                    b.Property<string>("NomePai")
                        .HasMaxLength(100);

                    b.Property<string>("Numero");

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.Property<string>("Sexo")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(10);

                    b.Property<string>("TipoPessoa")
                        .HasMaxLength(50);

                    b.HasKey("PessoaId");

                    b.HasIndex("CepId");

                    b.HasIndex("CidadeId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Plano", b =>
                {
                    b.Property<int>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .HasMaxLength(50);

                    b.HasKey("PlanoId");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Recibo", b =>
                {
                    b.Property<int>("ReciboId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correspondente")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DataRecibo");

                    b.Property<int>("PessoaId");

                    b.Property<int>("Proficional");

                    b.Property<decimal>("Valor");

                    b.HasKey("ReciboId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Cep", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Cidade", "Cidade")
                        .WithMany("Ceps")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Cidade", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloDeDados.Classes.ContaBancaria", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Estado", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Pessoa", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Cep", "Cep")
                        .WithMany("Pessoas")
                        .HasForeignKey("CepId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModeloDeDados.Classes.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloDeDados.Classes.Recibo", b =>
                {
                    b.HasOne("ModeloDeDados.Classes.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
