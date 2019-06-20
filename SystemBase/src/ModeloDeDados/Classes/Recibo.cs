using System;
using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Recibo
    {
        [Key]
        public int ReciboId { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int Proficional { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRecibo { get; set; }
        [StringLength(100)]
        public string Correspondente { get; set; }

    }
}
