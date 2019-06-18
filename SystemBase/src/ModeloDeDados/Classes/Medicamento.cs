using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Medicamento
    {
        [Key]
        public int MedicamentoId { get; set; }
        [StringLength(100)]
        public String Nome { get; set; }
        
        public String Descricao { get; set; }

        public int NumeroRegistro { get; set; }


    }
}
