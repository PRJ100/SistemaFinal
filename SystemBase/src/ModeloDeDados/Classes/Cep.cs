using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Cep
    {
        [Key]
        public int CepId { get; set; }
        [StringLength(25)]
        public string NumeroCep { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public List<Pessoa> Pessoas { get; set; }
    }
}
