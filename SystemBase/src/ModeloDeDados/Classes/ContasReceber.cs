using System;
using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class ContasReceber
    {
        [Key]
        public int ContasReceberId { get; set; }
        [StringLength(20)]
        public string CNPJ_CPF { get; set; }
        public DateTime Vencimento { get; set; }
        public string Descricao { get; set; }
        public string FormaPagamento { get; set; }
        [StringLength(20)]
        public string Contato { get; set; }
        public decimal Valor { get; set; }
    }
}
