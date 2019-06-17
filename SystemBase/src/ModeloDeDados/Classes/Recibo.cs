using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Recibo
    {
        [Key]
        public int ReciboId { get; set; }
        public int PessoaId { get; set; }
        [ForeignKey("PessoaId")]
        public Pessoa Pessoa { get; set; }
        public int Proficional { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRecibo { get; set; }
        [StringLength(100)]
        public string Correspondente { get; set; }

    }
}
