using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Banco
    {
        [Key]
        public int BancoId { get; set; }
        [StringLength(20)]
        public string Nome { get; set; }
        public int Codigo { get; set; }
    }
}
