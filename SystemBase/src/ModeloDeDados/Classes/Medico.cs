using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
   public  class Medico
    {
        [Key]
       
        public int Crm { get; set; }

        [StringLength(100)]
        public string Especialidade { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
