using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Faturamento
    {
        [Key]
        public int FaturamentoId { get; set; }
        [StringLength(20)]
        public string Tipo { get; set; }
        public DateTime DataConsulta { get; set; }
        [StringLength(20)]
        public string HorarioConsuta { get; set; }
        public int MedicoId { get; set; }
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
        public int PessoaId { get; set; }
        [ForeignKey("PessoaId")]
        public Pessoa Pessoa { get; set; }
        public int PlanoId { get; set; }
        [ForeignKey("PlanoId")]
        public Plano Plano { get; set; }
        [StringLength(30)]
        public string Status { get; set; }
        public decimal Valor { get; set; }
        [StringLength(40)]
        public string TipoPagamento { get; set; }
    }
}
