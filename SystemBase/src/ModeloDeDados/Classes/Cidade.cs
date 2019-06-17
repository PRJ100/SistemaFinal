using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }
        public List<Cep> Ceps { get; set; }
        public int CodigoIBGE { get; set; }
    }
}
