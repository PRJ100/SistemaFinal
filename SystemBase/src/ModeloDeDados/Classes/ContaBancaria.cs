using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class ContaBancaria
    {
        [Key]
        public int ContaBancariaId { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        public int BancoId { get; set; }
        public Banco Banco { get; set; }
        [StringLength(15)]
        public string Agencia { get; set; }
        [StringLength(15)]
        public string Conta { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public decimal Disponivel { get; set; }
        [StringLength(200)]
        public string Observacao { get; set; }
    }
}
