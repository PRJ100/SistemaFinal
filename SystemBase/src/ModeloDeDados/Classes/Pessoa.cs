using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        [StringLength(50)]
        public string TipoPessoa { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string NomePai { get; set; }
        [StringLength(100)]
        public string NomeMae { get; set; }
        [StringLength(50)]
        public string EstadoCivil { get; set; }
        [StringLength(50)]
        public string Naturalidade { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        [StringLength(50)]
        public string Sexo { get; set; }
        [StringLength(20)]
        public string CPF { get; set; }
        [StringLength(20)]
        public string RG { get; set; }
        [StringLength(80)]
        public string Contato { get; set; }
        public int CepId { get; set; }
        [ForeignKey("CepId")]
        public Cep Cep { get; set; }
        public int CidadeId { get; set; }
        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
        [StringLength(100)]
        public string Logradouro { get; set; }
        [StringLength(100)]
        public string Bairro { get; set; }
        public string Numero { get; set; }
        [StringLength(200)]
        public string Complemento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao {
            get { return DateTime.Now; }
        }
        [StringLength(10)]
        public string Status { get; set; }
    }
}
