using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public int CodigoTelefone { get; set; }
        public List<Estado> Estados { get; set; }       
    }
}
