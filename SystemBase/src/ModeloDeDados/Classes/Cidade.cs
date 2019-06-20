using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public List<Cep> Ceps { get; set; }
        public int CodigoIBGE { get; set; }
    }
}
