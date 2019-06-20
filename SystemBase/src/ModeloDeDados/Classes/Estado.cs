using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public List<Cidade> Cidades { get; set; }
        [StringLength(2)]
        public string Sigla { get; set; }
        public int CodigoIBGE { get; set; }

    }
}
